using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MoneyTracker.Application.CategoriesIcons.Commands;
public class SetCategoryIconCommandValidator : AbstractValidator<SetCategoryIconCommand>
{
    public SetCategoryIconCommandValidator()
    {
        RuleFor(x => x.CategoryId).NotEmpty();
        RuleFor(x => x.Icon).NotEmpty();
    }
}
