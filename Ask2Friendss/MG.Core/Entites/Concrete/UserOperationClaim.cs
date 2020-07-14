using MG.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Core.Entites.Concrete
{
    public class UserOperationClaim : BaseEntity<int>, IEntity
    {
        public Guid UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
