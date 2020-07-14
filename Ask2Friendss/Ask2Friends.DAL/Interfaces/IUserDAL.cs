using MG.Core.DAL;
using MG.Core.Dtos.Concrete;
using MG.Core.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask2Friends.DAL.Interfaces
{
    public interface IUserDAL : IEntityRepository<User>
    {
        List<UserOperationClaimDto> GetClaims(User user);
    }
}
