using MG.Core.Dtos.Concrete;
using MG.Core.Entites.Concrete;
using MG.Core.Utilities.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask2Friends.BLL.Interfaces
{
    public interface IUserService
    {
        IDataResult<List<UserOperationClaimDto>> GetClaims(User user);
        IResult AddAsync(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<List<UserDto>> GetAllUsers();
    }
}
