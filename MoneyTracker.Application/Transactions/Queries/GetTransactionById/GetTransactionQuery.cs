using ErrorOr;
using MediatR;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Transactions.Queries.GetAllTransactionsByUserId;

public record GetTransactionQuery(Guid id) : IRequest<ErrorOr<Transaction>>;