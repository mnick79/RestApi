using FluentValidation;
using RestApi.Models;

namespace RestApi.Models.Validation
{
    public class CartValidator : AbstractValidator<Cart>
    {
        public CartValidator()
        {
            RuleFor(cart => cart.Number).GreaterThanOrEqualTo(0).WithMessage("Number must is positive");

            RuleFor(cart => cart.Description)
                .NotEmpty().WithMessage("Input Description")
                .MaximumLength(250).WithMessage("The description must be shorter than 250 characters");

            RuleFor(cart => cart.CustomerNumber)
                .NotEmpty().WithMessage("CustomerNumber cannot be empty")
                .GreaterThan(0).WithMessage("CustomerNumber must is number and positive");

        }
    }
}
