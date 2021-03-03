using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserAuthManager : IUserAuthService
    {
        IUserAuthDal _userAuthDal;

        public UserAuthManager(IUserAuthDal userAuthDal)
        {
            _userAuthDal = userAuthDal;
        }

        public List<OperationClaim> GetClaims(UserAuth user)
        {
            return _userAuthDal.GetClaims(user);
        }

        public void Add(UserAuth user)
        {
            _userAuthDal.Add(user);
        }

        public UserAuth GetByMail(string email)
        {
            return _userAuthDal.Get(u => u.Email == email);
        }
    }
}
