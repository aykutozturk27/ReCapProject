using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(UserAuth user, List<OperationClaim> operationClaims);
    }
}
