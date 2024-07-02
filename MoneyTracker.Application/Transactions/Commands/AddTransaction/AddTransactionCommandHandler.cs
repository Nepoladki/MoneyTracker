using System.Data;
using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Transactions;

public class AddTransactionCommandHandler
 : IRequestHandler<AddTransactionCommand, ErrorOr<Guid>>
{
    private readonly ITransactionRepository _transactionRepository;

    public AddTransactionCommandHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<ErrorOr<Guid>> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (request.Amount <= 0)
            return Errors.Transactions.InvalidAmount;
        
        if (request.CategoryId == Guid.Empty)
            return Errors.Transactions.InvalidCategoryId;

        if (request.UserId == Guid.Empty)
            return Errors.Transactions.InvalidUserId;

        var transaction = new Transaction(
            request.Amount,
            request.CategoryId,
            request.UserId,
            request.Note,
            request.DateTime
        );
        
        if (_transactionRepository.Add(transaction) == false)
            return Errors.Transactions.RepositoryError;

        return transaction.Id;
    }
}