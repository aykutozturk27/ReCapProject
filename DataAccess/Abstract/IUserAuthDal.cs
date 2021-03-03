using Core.DataAccess;
using Core.Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserAuthDal : IEntityRepository<UserAuth>
    {
        List<OperationClaim> GetClaims(UserAuth user);
    }
}
