using FluentValidation;
using Para.Schema;

namespace Para.Bussiness.Validations
{
    public class CustomerAddressValidator : AbstractValidator<CustomerAddressRequest>
    {
        public CustomerAddressValidator()
        {
            RuleFor(x => x.Country)
                .NotEmpty()
                .Length(1, 80)
                .WithMessage("Country name must be between 1 and 80 characters!");

            RuleFor(x => x.City)
                .NotEmpty()
                .Length(1, 80)
                .WithMessage("City name must be between 1 and 80 characters!");

            RuleFor(x => x.AddressLine)
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("Address line cannot exceed 200 characters!");

            RuleFor(x => x.ZipCode)
                .NotEmpty()
                .Length(11)
                .WithMessage("Zip code must be exactly 11 characters long!");
        }
    }
}
