using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class AnnalValidator : AbstractValidator<Annal>
    {
        public AnnalValidator()
        {
            RuleFor(c => c.Time).NotEmpty();
            RuleFor(c => c.Event).MinimumLength(2);
            RuleFor(c => c.Category).NotEmpty();
           
        }
    }
}
