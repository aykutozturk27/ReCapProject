using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserAuthService _userAuthService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserAuthService userAuthService, ITokenHelper tokenHelper)
        {
            _userAuthService = userAuthService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<UserAuth> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new UserAuth
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userAuthService.Add(user);
            return new SuccessDataResult<UserAuth>(user, Messages.UserAdded);
        }

        public IDataResult<UserAuth> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userAuthService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<UserAuth>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<UserAuth>(Messages.WrongPassword);
            }

            return new SuccessDataResult<UserAuth>(userToCheck, Messages.LoginSuccessfull);
        }

        public IResult UserExists(string email)
        {
            if (_userAuthService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(UserAuth user)
        {
            var claims = _userAuthService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.TokenCreated);
        }
    }
}
