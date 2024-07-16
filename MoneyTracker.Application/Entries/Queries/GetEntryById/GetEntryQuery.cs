using ErrorOr;
using MediatR;
using MoneyTracker.Application.Entries.Common;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Entries.Queries.GetAllEntriesByUserId;

public record GetEntryQuery(Guid id) : IRequest<ErrorOr<EntryDto>>;