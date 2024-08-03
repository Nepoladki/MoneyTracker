using ErrorOr;
using MediatR;
using MoneyTracker.Application.Categories.Common;

namespace MoneyTracker.Application.Categories.Commands.AddCategory;

public record AddCategoryCommand(
    string CategoryName,
    bool IsPublic,
    Guid? CreatedByUserId) : IRequest<ErrorOr<CategoryDto>>;

