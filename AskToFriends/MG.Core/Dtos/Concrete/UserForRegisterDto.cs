using MG.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Core.Dtos.Concrete
{
    public class UserForRegisterDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
