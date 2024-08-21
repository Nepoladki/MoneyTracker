using FluentValidation;
using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Application.Categories.Commands.AddCategory;
public class AddCategoryValidator : AbstractValidator<AddCategoryCommand>
{
    public AddCategoryValidator()
    {
        RuleFor(x => x.CategoryName).NotEmpty();
        RuleFor(x => x.CategoryType).IsEnumName(typeof(CategoryType));
    }
}