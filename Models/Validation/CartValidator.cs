using FluentValidation;
using RestApi.Models;
using System.Linq;

namespace RestApi.Models.Validation
{
    public class CartValidator : AbstractValidator<Cart>
    {
        public CartValidator()
        {
            RuleFor(cart => cart.Number).GreaterThanOrEqualTo(0).WithMessage("Number must is positive");

            RuleFor(cart => cart.Description)
                .Must(descript => new[] { "", "string" }.Contains(descript))
                .WithMessage("Description must is 'string' or empty. Autocomplete is used");

            RuleFor(cart => cart.TotalPrice)
                .Equal(0)
                .WithMessage("TotalPrice must is 0. Autocomplete is used");

            RuleFor(cart => cart.CustomerNumber)
                .NotEmpty().WithMessage("CustomerNumber cannot be empty")
                .GreaterThan(0).WithMessage("CustomerNumber must is number and positive");

        }
    }
}
