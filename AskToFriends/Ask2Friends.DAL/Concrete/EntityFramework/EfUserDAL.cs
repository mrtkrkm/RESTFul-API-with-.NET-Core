using Ask2Friends.DAL.Concrete.EntityFramework.Contexts;
using Ask2Friends.DAL.Interfaces;
using MG.Core.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MG.Core.Entites.Concrete;
using MG.Core.Dtos.Concrete;

namespace Ask2Friends.DAL.Concrete.EntityFramework
{
    public class EfUserDAL : EfEntityRepositoryBase<User, Ask2FriendsDbContext>, IUserDAL
    {
        public List<UserOperationClaimDto> GetClaims(User user)
        {
            using (var context = new Ask2FriendsDbContext())
            {
                var result = (from operationClaim in context.OperationClaim
                             join userOperationClaim in context.UserOperationClaim
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new UserOperationClaimDto { ClaimId = operationClaim.Id, ClaimName = operationClaim.Name }).ToList();

                return result;
            }
        }
    }
}
