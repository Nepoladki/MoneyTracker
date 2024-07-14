using ErrorOr;
using MediatR;

namespace MoneyTracker.Application.Entries.Commands.UpdateEntry;
public record UpdateEntryCommand(
    Guid Id,
    decimal Amount,
    string CurrencyAbbr,
    Guid CategoryId,
    string Note,
    DateTime DateTime,
    Guid UserId) : IRequest<ErrorOr<Guid>>;