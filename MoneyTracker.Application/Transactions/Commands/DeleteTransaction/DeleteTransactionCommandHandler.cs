using System.Data.Common;
using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Transactions.Commands.DeleteTransaction;

public class DeleteTransactionCommandHandler :
    IRequestHandler<DeleteTransactionCommand, ErrorOr<Guid>>
{
    private readonly ITransactionRepository _transactionRepository;

    public DeleteTransactionCommandHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<ErrorOr<Guid>> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        //Validate if transaction exists
        if (_transactionRepository.GetTransactionById(request.id) is not Transaction transaction)
            return Errors.Transactions.TransactionNotFound;

        if (!_transactionRepository.Delete(transaction))
            return Errors.Transactions.RepositoryError;

        return request.id;


    }
}