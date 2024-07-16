using ErrorOr;
using MediatR;
using MoneyTracker.Application.Entries.Common;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Entries.Queries.GetAllEntriesForUser;

public record GetAllEntriesForUserQuery(Guid UserId) : IRequest<ErrorOr<ICollection<EntryDto>>>;