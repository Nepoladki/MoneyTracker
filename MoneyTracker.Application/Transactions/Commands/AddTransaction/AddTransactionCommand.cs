using MediatR;

namespace MoneyTracker.Application.Transactions;

public record AddTransactionCommand(
    decimal Amount,
    Guid CategoryId,
    string Note,
    DateTime DateTime,
    Guid UserId) : IRequest<Guid>;
