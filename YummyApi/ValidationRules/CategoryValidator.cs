using FluentValidation;
using YummyApi.Entities;

namespace YummyApi.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category name cannot be empty.")
                .MinimumLength(3).WithMessage("Category name cannot be shorter than 2 characters.")
                .MaximumLength(75).WithMessage("Category name can be a maximum of 75 characters.");
        }
    }
}
