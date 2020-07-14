using MG.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask2Friends.Entities
{
    public class UserQuestion : BaseEntity<Guid>, IEntity
    {
        public Guid UserId { get; set; }
        public Guid RoomQuestionId { get; set; }
    }
}
