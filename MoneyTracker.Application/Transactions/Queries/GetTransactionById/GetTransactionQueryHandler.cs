using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Transactions.Queries.GetAllTransactionsByUserId;

public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, ErrorOr<Transaction>>
{
    private readonly ITransactionRepository _repository;

    public GetTransactionQueryHandler(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<Transaction>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        if (_repository.GetTransactionById(request.id) is not Transaction transaction)
            return Errors.Transactions.TransactionNotFound;

        return transaction;
    }
}
