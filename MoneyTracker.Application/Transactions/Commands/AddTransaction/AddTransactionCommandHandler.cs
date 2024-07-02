using ErrorOr;
using MediatR;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Common.Errors;

namespace MoneyTracker.Application.Transactions;

public class AddTransactionCommandHandler
 : IRequestHandler<AddTransactionCommand, Guid>
{
    private readonly ITransactionRepository _tranactionRepository;

    public AddTransactionCommandHandler(ITransactionRepository tranactionRepository)
    {
        _tranactionRepository = tranactionRepository;
    }

    public async Task<ErrorOr<Guid>> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        //Validate 
        if (request.Amount <= 0)
            return Errors.Transactions.InvalidAmount;
        
        if (request.CategoryId == Guid.Empty)
            return Errors.Transactions.InvalidCategoryId;

        _tranactionRepository.Add()
    }
}