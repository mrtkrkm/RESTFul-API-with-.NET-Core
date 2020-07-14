using FluentValidation;
using MG.Core.Dtos.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask2Friends.BLL.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).Length(3, 50);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).Length(3, 50);
            RuleFor(u => u.Username).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Gender).Must(GenderControl);
        }

        private bool GenderControl(string arg)
        {
            return arg.ToUpper().Equals("F") || arg.ToUpper().Equals("M");
        }
    }
}
