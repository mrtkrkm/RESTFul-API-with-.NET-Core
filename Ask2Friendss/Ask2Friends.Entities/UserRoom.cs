using MG.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask2Friends.Entities
{
    public class UserRoom : BaseEntity<int>, IEntity
    {
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
    }
}
