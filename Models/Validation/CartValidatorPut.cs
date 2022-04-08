using FluentValidation;
using RestApi.Models;
using RestApi.Models.Validation;

namespace RestApi.Domains.Validation
{
    public class CartValidatorPut: AbstractValidator<Cart>
    {
        public CartValidatorPut()
        {
            RuleFor(cart => cart.Number).GreaterThan(0).WithMessage("Number must is positive");

            RuleFor(cart => cart.Description)
                .NotEmpty().WithMessage("Input Description")
                .NotEqual("string").WithMessage("Not must is string")
                .MaximumLength(250).WithMessage("The FistName must be shorter than 250 characters");
            RuleFor(cart => cart.CustomerNumber)
                .NotEmpty().WithMessage("FistName cannot be empty")
                .GreaterThan(0).WithMessage("Totalprice must is positive");

        }
    }
}
