using ErrorOr;
using MediatR;
using MoneyTracker.Application.Entries.Common;

namespace MoneyTracker.Application.Entries.Queries.GetAllEntriesForUserGroupedByCategory;
public record GetAllEntriesForUserGroupedByCategoryQuery(Guid userId) : IRequest<ErrorOr<ICollection<EntriesByCategoriesOuterDto>>>;
