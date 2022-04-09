using FluentValidation;
using RestApi.Models;

namespace RestApi.Models.Validation
{
    public class CartValidator : AbstractValidator<Cart>
    {
        public CartValidator()
        {
            RuleFor(cart => cart.Number).GreaterThan(0).WithMessage("PUT  Number must is positive");

            RuleFor(cart => cart.Description)
                .NotEmpty().WithMessage("Input Description")
                .NotEqual("string").WithMessage("Not must is string")
                .MaximumLength(250).WithMessage("The description must be shorter than 250 characters");

            RuleFor(cart => cart.CustomerNumber)
                .NotEmpty().WithMessage("CustomerNumber cannot be empty")
                .GreaterThan(0).WithMessage("CustomerNumber must is number and positive");

        }
    }
}
