using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).GreaterThan(DateTime.Now).WithMessage("Rent date not valid. It can not be a past date!");
        }
    }
}
