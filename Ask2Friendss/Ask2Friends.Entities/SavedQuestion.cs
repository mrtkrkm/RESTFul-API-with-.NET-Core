using MG.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask2Friends.Entities
{
    public class SavedQuestion : BaseEntity<Guid>, IEntity
    {
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public int LevelId { get; set; }
    }
}
