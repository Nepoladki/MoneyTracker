using ErrorOr;
using MediatR;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Entries.Queries.GetAllEntriesByUserId;

public record GetEntryQuery(Guid id) : IRequest<ErrorOr<Entry>>;