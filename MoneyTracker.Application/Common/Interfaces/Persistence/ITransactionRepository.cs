using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Interfaces.Persistence;

public interface ITransactionRepository
{
    public ICollection<Transaction> GetAllTransactionsByUserId(Guid id);
    public Transaction? GetTransactionById(Guid id);
    public bool TransactionExists(Guid id);
    public bool Add(Transaction transaction);
    public bool Delete(Transaction transaction);
    public bool Save();
}