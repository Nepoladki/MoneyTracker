using ErrorOr;
using MediatR;
using MoneyTracker.Application.Categories.Common;

namespace MoneyTracker.Application.Categories.Queries.GetAllCategoriesForUser;
public record GetAllCategoriesForUserQuery(Guid UserId) : IRequest<ErrorOr<ICollection<CategoryDto>>>;
