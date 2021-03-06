using FluentValidation;
using RestApi.Models;

namespace RestApi.Domains.Validation
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //RuleFor(product => product.Number).Equal(0).WithMessage("Number isn't used");
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .MinimumLength(1).WithMessage("Short name Name")
                .MaximumLength(250).WithMessage("The FistName must be shorter than 250 characters");
            RuleFor(product => product.Price)
                .NotEmpty().WithMessage("Price cannot be empty")
                .GreaterThan(0).WithMessage("Price must is positive");
        }
    }
}
