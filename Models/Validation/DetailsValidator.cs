using FluentValidation;
using RestApi.Models;

namespace RestApi.Domains.Validation
{
    public class DetailsValidator: AbstractValidator<Details>
    {
        public DetailsValidator()
        {
            //RuleFor(customer => customer.Number).Equal(0).WithMessage("Number isn't used");
            RuleFor(details => details.CartNumber)
                .NotEmpty().WithMessage("FistName cannot be empty")
                .GreaterThan(0).WithMessage("Price must is positive");
            RuleFor(details => details.ProductNumber)
                .NotEmpty().WithMessage("FistName cannot be empty")
                .GreaterThan(0).WithMessage("Price must is positive");
            RuleFor(details => details.Count)
                .NotEmpty().WithMessage("FistName cannot be empty")
                .GreaterThan(0).WithMessage("Price must is positive");
        }
    }
}
