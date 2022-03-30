using FluentValidation;
namespace RestApi.Domains.Validation
{
    public class CartValidator: AbstractValidator<Cart>
    {
        public CartValidator()
        {
            RuleFor(cart => cart.Number).Equal(0).WithMessage("Number isn't used");

            RuleFor(cart => cart.Description)
                .MaximumLength(250).WithMessage("The FistName must be shorter than 250 characters");
            RuleFor(cart => cart.CustomerNumber)
                .NotEmpty().WithMessage("FistName cannot be empty")
                .GreaterThan(0).WithMessage("Price must is positive");

        }
    }
}
