using FluentValidation;
using Para.Schema;

namespace Para.Bussiness.Validations
{
    public class CustomerValidator : AbstractValidator<CustomerRequest>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Length(2, 50)
                .WithMessage("First name must contain between 2 and 50 characters!");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .Length(2, 50)
                .WithMessage("Last name must contain between 2 and 50 characters!");

            RuleFor(x => x.IdentityNumber)
                .NotEmpty()
                .Length(11)
                .WithMessage("Identity number must be exactly 11 characters long!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .Length(12, 150)
                .WithMessage("Email address must be between 12 and 150 characters!");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of birth is required!");

            RuleFor(x => x.CustomerNumber)
                .NotEmpty()
                .InclusiveBetween(1, 100000)
                .WithMessage("Customer number must be within the range of 1 to 100000!");
        }
    }
}