using FluentValidation;
using YummyApi.Entities;

namespace YummyApi.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("The product name cannot be empty.");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Product name cannot be shorter than 2 characters.");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("Product name can be a maximum of 50 characters.");

            RuleFor(x => x.Price).NotEmpty().WithMessage("The product price cannot be empty.")
                .GreaterThan(0).WithMessage("Product price cannot be negative.");
            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("The product description cannot be empty.")
                .MinimumLength(10).WithMessage("Product description cannot be shorter than 10 characters.")
                .MaximumLength(500).WithMessage("Product description can be a maximum of 500 characters.");
        }
    }
}
