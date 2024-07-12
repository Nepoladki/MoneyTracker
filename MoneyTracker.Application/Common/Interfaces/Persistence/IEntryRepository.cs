using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Interfaces.Persistence;

public interface IEntryRepository
{
    public ICollection<Entry> GetAllEntriesByUserId(Guid id);
    public Entry? GetEntryById(Guid id);
    public bool EntryExists(Guid id);
    public Task<ICollection<Entry>> GetAllEntriesAsync();
    public bool Add(Entry entry);
    public bool Delete(Entry entry);
    public bool Save();
}