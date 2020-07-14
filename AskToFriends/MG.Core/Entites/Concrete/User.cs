using MG.Core.Entites;
using System;
using System.Collections.Generic;

namespace MG.Core.Entites.Concrete
{
    public class User : BaseEntity<Guid>, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
