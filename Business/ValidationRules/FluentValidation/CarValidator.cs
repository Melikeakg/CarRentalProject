using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).MinimumLength(2).WithMessage(ValidationMessages.CarNameValid);
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage(ValidationMessages.DailyPriceValid);
            RuleFor(c => c.Description).NotEmpty().WithMessage(ValidationMessages.DescriptionValid);
            RuleFor(c => c.ModelYear).GreaterThan(2000).WithMessage(ValidationMessages.ModelValid);
        }
    }
}
