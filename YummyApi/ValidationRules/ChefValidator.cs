using FluentValidation;
using YummyApi.Entities;

namespace YummyApi.ValidationRules
{
    public class ChefValidator:AbstractValidator<Chef>
    {
        public ChefValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Chef name is cannot be an empty.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is cannot be an empty.");
        }
    }
}
