using FluentValidation;
using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Application.Categories.Commands.UpdateCategory;
public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.CategoryName).NotEmpty();
        RuleFor(x => x.CategoryType).IsEnumName(typeof(CategoryType));
    }
}