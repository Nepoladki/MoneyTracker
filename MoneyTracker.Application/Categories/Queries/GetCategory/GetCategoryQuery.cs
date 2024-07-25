using ErrorOr;
using MediatR;
using MoneyTracker.Application.Categories.Common;

namespace MoneyTracker.Application.Categories.Queries.GetCategory;
public record GetCategoryQuery(Guid Id) : IRequest<ErrorOr<CategoryDto>>;
