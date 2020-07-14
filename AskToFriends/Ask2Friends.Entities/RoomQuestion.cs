using MG.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask2Friends.Entities
{
    public class RoomQuestion : BaseEntity<Guid>, IEntity
    {
        public Guid RoomId { get; set; }
        public string Question { get; set; }
        public int LevelId { get; set; }
    }
}
