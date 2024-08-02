using ErrorOr;
using MediatR;
using MoneyTracker.Application.Categories.Common;

namespace MoneyTracker.Application.Categories.Queries.GetAllPublicCategories;
public record GetAllPublicCategoriesQuery : IRequest<ErrorOr<ICollection<CategoryDto>>>;
