using Core.Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisterValidator :AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.FirstName).MinimumLength(3);
            RuleFor(u => u.LastName).MinimumLength(3);
            RuleFor(u => u.Password).NotEmpty().WithMessage("Bir parola belirleyiniz.");
        }
    }
}
