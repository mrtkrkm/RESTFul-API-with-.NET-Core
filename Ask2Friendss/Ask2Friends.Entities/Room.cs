using MG.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask2Friends.Entities
{
    public class Room : BaseEntity<Guid>, IEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
