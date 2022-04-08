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

