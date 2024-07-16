using FluentValidation;

namespace MoneyTracker.Application.Categories.Commands.AddCategory;
public class AddCategoryValidator : AbstractValidator<AddCategoryCommand>
{
    public AddCategoryValidator()
    {
        RuleFor(x => x.CategoryName).NotEmpty();
    }
}