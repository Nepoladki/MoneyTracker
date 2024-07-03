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
        _transactionContext.Transactions.Add(transaction);
        return Save();
    }

    public ICollection<Transaction> GetAllTransactionsByUserId(Guid id)
    {
        return _transactionContext.Transactions.OrderBy(x => x.DateTime).ToList();
    }

    public Transaction? GetTransactionById(Guid id)
    {
        return _transactionContext.Transactions.FirstOrDefault(t => t.Id == id); //надо решить как обрабатывать случаи когда такой транзакции нет
    }

    public bool Save() => _transactionContext.SaveChanges() > 0;
}