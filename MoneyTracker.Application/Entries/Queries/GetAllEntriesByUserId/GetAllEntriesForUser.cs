using ErrorOr;
using MediatR;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Entries.Queries.GetAllEntriesByUserId;

public record GetAllEntriesForUser(Guid UserId) : IRequest<ErrorOr<ICollection<Entry>>>;