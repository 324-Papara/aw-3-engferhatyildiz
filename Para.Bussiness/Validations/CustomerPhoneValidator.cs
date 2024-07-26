using FluentValidation;
using Para.Schema;

namespace Para.Bussiness.Validations
{
    public class CustomerPhoneValidator : AbstractValidator<CustomerPhoneRequest>
    {
        public CustomerPhoneValidator()
        {
            RuleFor(x => x.CountyCode)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Country Code must be at least 3 characters long!");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .Length(10)
                .WithMessage("Phone number must be exactly 10 characters long!");
        }
    }
}
