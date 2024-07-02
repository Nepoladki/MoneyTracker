using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Infrastructure.Persistence;

public class TransactionRepository : ITransactionRepository
{
    private readonly DataContext _transactionContext;

    public TransactionRepository(DataContext transactionContext)
    {
        _transactionContext = transactionContext;
    }

    public bool Add(Transaction transaction)
    {
        throw new NotImplementedException();
    }

    public ICollection<Transaction> GetAllTransactionsByUserId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Transaction? GetTransactionById(string email)
    {
        throw new NotImplementedException();
    }
}