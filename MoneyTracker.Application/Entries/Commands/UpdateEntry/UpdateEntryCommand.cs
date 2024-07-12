using ErrorOr;
using MediatR;

namespace MoneyTracker.Application.Entries.Commands.UpdateEntry;
public record UpdateEntryCommand(
    Guid Id,
    decimal Amount,
    Guid CategoryId,
    string Note,
    Guid UserId) : IRequest<ErrorOr<Guid>>;