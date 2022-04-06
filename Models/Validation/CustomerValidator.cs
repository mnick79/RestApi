using FluentValidation;
using System.Linq;

namespace RestApi.Domains.Validation
{
    public class CustomerValidator : AbstractValidator<CustomerOld>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Number).Equal(0).WithMessage("Number isn't used");
            RuleFor(customer => customer.FistName)
                .NotEmpty().WithMessage("FistName cannot be empty")
                .MinimumLength(1).WithMessage("Short name FistName")
                .MaximumLength(250).WithMessage("The FistName must be shorter than 250 characters");
            RuleFor(customer => customer.LastName)
                .NotEmpty().WithMessage("LastName cannot be empty")
                .MinimumLength(1).WithMessage("Short name LastName")
                .MaximumLength(250).WithMessage("The LastName must be shorter than 250 characters");
            RuleFor(customer => customer.Address)
                .NotEmpty().WithMessage("Address cannot be empty")
                .MinimumLength(1).WithMessage("Short name Address")
                .MaximumLength(250).WithMessage("The Address must be shorter than 250 characters");
            RuleFor(customer => customer.Vip)
                .Must(vip => (new[] { "False", "True" }).Contains(vip.ToString()))
                //.Must(vip => (vip.ToString() == "True" || vip.ToString() == "False"))
                .WithMessage("Vip must be false or true");

        }
    }
}
