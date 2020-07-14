using MG.Core.Dtos.Concrete;
using MG.Core.Entites.Concrete;
using MG.Core.Utilities.Results.Interfaces;
using MG.Core.Utilities.Security.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask2Friends.BLL.Interfaces
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
