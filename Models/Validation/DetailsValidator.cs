using FluentValidation;
using RestApi.Models;

namespace RestApi.Domains.Validation
{
    public class DetailsValidator: AbstractValidator<Details>
    {
        public DetailsValidator()
        {
            RuleFor(customer => customer.Number).GreaterThanOrEqualTo(0).WithMessage("Number must be greater that or equal 0");

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
