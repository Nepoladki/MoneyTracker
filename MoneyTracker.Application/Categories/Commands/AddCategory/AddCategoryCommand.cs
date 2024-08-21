using ErrorOr;
using MediatR;
using MoneyTracker.Application.Categories.Common;
using MoneyTracker.Domain.Enums;

namespace MoneyTracker.Application.Categories.Commands.AddCategory;

public record AddCategoryCommand(
    string CategoryName,
    string CategoryType,
    bool IsPublic,
    Guid? CreatedByUserId) : IRequest<ErrorOr<CategoryDto>>;

