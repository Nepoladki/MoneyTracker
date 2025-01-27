using ErrorOr;
using MediatR;

namespace MoneyTracker.Application.Entries.Commands.AddEntry;

public class AddEntryCommand : IRequest<ErrorOr<Guid>>
{
    public decimal Amount { get; init; }
    public Guid CategoryId { get; init; }
    public string Note { get; init; } = null!;
    public DateTime DateTime { get; init; } = DateTime.UtcNow;
    public Guid UserId { get; init; }
}
