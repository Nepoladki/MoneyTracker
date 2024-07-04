using ErrorOr;
using MediatR;

namespace MoneyTracker.Application.Transactions.Commands.DeleteTransaction;

public record DeleteTransactionCommand(Guid id) : IRequest<ErrorOr<Guid>>;