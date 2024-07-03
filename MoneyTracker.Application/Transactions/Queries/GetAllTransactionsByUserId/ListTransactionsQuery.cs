using ErrorOr;
using MediatR;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Transactions.Queries.GetAllTransactionsByUserId;

public record ListTransactionQuery(Guid userId) : IRequest<ErrorOr<ICollection<Transaction>>>;