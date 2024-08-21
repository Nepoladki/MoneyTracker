using ErrorOr;
using MediatR;

namespace MoneyTracker.Application.Categories.Commands.UpdateCategory;
public record UpdateCategoryCommand(
    Guid Id,
    string CategoryName,
    string CategoryType) : IRequest<ErrorOr<Guid>>;