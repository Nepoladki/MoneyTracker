using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Interfaces.Persistence;

public interface ITransactionRepository
{
    ICollection<Transaction> GetAllTransactionsByUserId(Guid id);
    Transaction? GetTransactionById(string email);
    bool Add(Transaction transaction);
}