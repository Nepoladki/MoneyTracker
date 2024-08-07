using ErrorOr;
using MediatR;

namespace MoneyTracker.Application.CategoriesIcons.Queries;
public record GetCategoryIconQuery(Guid UserId, Guid CatId) : IRequest<ErrorOr<byte[]>>;
