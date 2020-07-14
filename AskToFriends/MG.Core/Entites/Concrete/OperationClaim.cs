using MG.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Core.Entites.Concrete
{
    public class OperationClaim : BaseEntity<int>, IEntity
    {
        public string Name { get; set; }
    }
}
