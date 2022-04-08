using FluentValidation;

namespace RestApi.Models.Validation
{
    public class CartValidatorPost : AbstractValidator<Cart>
    {
        public CartValidatorPost()
        {
            RuleFor(cart => cart.Number).Equal(0).WithMessage("Number isn't used");
            RuleFor(cart => cart.TotalPrice).Equal(0).WithMessage("Number isn't used");
            RuleFor(cart => cart.Description)
                .Equal("string").WithMessage("Description isn't used");
            RuleFor(cart => cart.CustomerNumber)
                .GreaterThan(0).WithMessage("Price must is positive");

        }
    }
}