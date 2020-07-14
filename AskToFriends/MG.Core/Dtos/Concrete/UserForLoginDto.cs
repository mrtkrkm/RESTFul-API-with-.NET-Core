using MG.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Core.Dtos.Concrete
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
