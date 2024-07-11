using Microsoft.EntityFrameworkCore;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Infrastructure.Persistence;

public class TransactionRepository : ITransactionRepository
{
    private readonly DataContext _context;

    public TransactionRepository(DataContext transactionContext)
    {
        _context = transactionContext;
    }

    public bool Add(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        return Save();
    }

    public bool TransactionExists(Guid id)
    {
        return _context.Transactions.Any(t => t.Id == id);
    }

    public ICollection<Transaction> GetAllTransactionsByUserId(Guid id)
    {
        return _context.Transactions.Where(t => t.UserId == id).OrderBy(x => x.DateTime).ToList();
    }

    public Transaction? GetTransactionById(Guid id)
    {
        return _context.Transactions.FirstOrDefault(t => t.Id == id);
    }

    public async Task<ICollection<Transaction>> GetAllTransactionsAsync()
    {
        return await _context.Transactions.ToListAsync();
    }

    public bool Save() => _context.SaveChanges() > 0;

    public bool Delete(Transaction transaction)
    {
        _context.Transactions.Remove(transaction);
        return Save();
    }
}