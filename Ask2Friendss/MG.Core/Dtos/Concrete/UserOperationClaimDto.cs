using MG.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Core.Dtos.Concrete
{
    public class UserOperationClaimDto : IDto
    {
        public int ClaimId { get; set; }
        public string ClaimName { get; set; }
    }
}
