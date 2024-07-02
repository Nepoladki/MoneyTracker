using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Interfaces.Persistence;

public interface ITransactionRepository
{
    ICollection<Transaction> GetAllTransactionsByUserId(Guid id);
    Transaction? GetTransactionById(Guid id);
    bool Add(Transaction transaction);
    public bool Save();
}