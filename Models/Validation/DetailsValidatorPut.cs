using FluentValidation;

namespace RestApi.Models.Validation
{
    public class DetailsValidatorPut: AbstractValidator<Details>
    {
        public DetailsValidatorPut()
        {
            RuleFor(customer => customer.Number)
                .NotEmpty().WithMessage("Number cannot be empty")
                .GreaterThan(0).WithMessage("Number must is positive");

            RuleFor(details => details.CartNumber)
                .NotEmpty().WithMessage("CartNumber cannot be empty")
                .GreaterThan(0).WithMessage("CartNumber must is positive");

            RuleFor(details => details.ProductNumber)
                .NotEmpty().WithMessage("ProductNumber cannot be empty")
                .GreaterThan(0).WithMessage("ProductNumber must is positive");

            RuleFor(details => details.Count)
                .NotEmpty().WithMessage("Count cannot be empty")
                .GreaterThan(0).WithMessage("Count must is positive");
        }
    }
}

