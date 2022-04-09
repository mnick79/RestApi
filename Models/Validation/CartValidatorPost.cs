using FluentValidation;
using System.Linq;

namespace RestApi.Models.Validation
{
    public class CartValidatorPost : AbstractValidator<Cart>
    {
        public CartValidatorPost()
        {

            RuleFor(cart => cart.Number).Equal(0).WithMessage("POST Number isn't used");
            RuleFor(cart => cart.TotalPrice).Equal(0).WithMessage("Number isn't used");
            RuleFor(cart => cart.Description)
                .Must(descript => (new[] { "", "string" }).Contains(descript))
                .WithMessage("Description must be string or empty");

            RuleFor(cart => cart.CustomerNumber)
                .GreaterThan(0).WithMessage("Price must is positive");
        }
    }
}