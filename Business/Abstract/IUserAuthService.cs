using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserAuthService
    {
        List<OperationClaim> GetClaims(UserAuth user);
        void Add(UserAuth user);
        UserAuth GetByMail(string email);
    }
}
