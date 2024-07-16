using MediatR;
using MoneyTracker.Application.Entries.Common;

namespace MoneyTracker.Application.Entries.Queries.GetAllEntries
{
    public record GetAllEntriesQuery : IRequest<ICollection<EntryDto>>;
}
