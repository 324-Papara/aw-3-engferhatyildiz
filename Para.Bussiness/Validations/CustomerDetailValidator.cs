using FluentValidation;
using Para.Schema;

namespace Para.Bussiness.Validations
{
    public class CustomerDetailValidator : AbstractValidator<CustomerDetailRequest>
    {
        public CustomerDetailValidator()
        {
            RuleFor(x => x.FatherName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Father's name cannot exceed 50 characters!");

            RuleFor(x => x.MotherName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Mother's name cannot exceed 50 characters!");

            RuleFor(x => x.MontlyIncome)
                .NotEmpty()
                .MaximumLength(10)
                .WithMessage("Monthly income cannot exceed 10 characters!");

            RuleFor(x => x.Occupation)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Occupation cannot exceed 50 characters!");
        }
    }
}
