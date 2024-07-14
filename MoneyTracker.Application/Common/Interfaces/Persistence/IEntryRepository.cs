using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Interfaces.Persistence;

public interface IEntryRepository
{
    public Task<ICollection<Entry>> GetAllEntriesByUserIdAsync(Guid id);
    public Task<Entry?> GetEntryByIdAsync(Guid id);
    public Task<bool> EntryExistsAsync(Guid id);
    public Task<ICollection<Entry>> GetAllEntriesAsync();
    public Task<bool> AddAsync(Entry entry);
    public Task<bool> DeleteAsync(Entry entry);
    public Task<bool> SaveAsync();
}