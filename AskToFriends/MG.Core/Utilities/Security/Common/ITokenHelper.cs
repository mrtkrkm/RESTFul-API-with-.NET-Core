using MG.Core.Dtos.Concrete;
using MG.Core.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Core.Utilities.Security.Common
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<UserOperationClaimDto> claims);
    }
}
