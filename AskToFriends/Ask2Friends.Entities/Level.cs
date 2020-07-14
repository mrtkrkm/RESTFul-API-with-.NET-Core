using MG.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask2Friends.Entities
{
    public class Level : BaseEntity<int>, IEntity
    {
        public string Name { get; set; }
    }
}
