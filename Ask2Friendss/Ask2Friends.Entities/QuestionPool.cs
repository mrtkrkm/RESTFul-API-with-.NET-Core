using MG.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask2Friends.Entities
{
    public class QuestionPool : BaseEntity<Guid>, IEntity
    {
        public string Content { get; set; }
    }
}
