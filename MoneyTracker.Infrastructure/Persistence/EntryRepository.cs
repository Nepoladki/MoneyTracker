using Microsoft.EntityFrameworkCore;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Infrastructure.Persistence;

public class EntryRepository : IEntryRepository
{
    private readonly DataContext _context;

    public EntryRepository(DataContext entryContext)
    {
        _context = entryContext;
    }

    public bool Add(Entry entry)
    {
        _context.Entries.Add(entry);
        return Save();
    }

    public bool EntryExists(Guid id)
    {
        return _context.Entries.Any(t => t.Id == id);
    }

    public ICollection<Entry> GetAllEntriesByUserId(Guid id)
    {
        return _context.Entries.Where(e => e.UserId == id).OrderBy(x => x.DateTime).ToList();
    }

    public Entry? GetEntryById(Guid id)
    {
        return _context.Entries.FirstOrDefault(t => t.Id == id);
    }

    public async Task<ICollection<Entry>> GetAllEntriesAsync()
    {
        return await _context.Entries.ToListAsync();
    }

    public bool Save() => _context.SaveChanges() > 0;

    public bool Delete(Entry entry)
    {
        _context.Entries.Remove(entry);
        return Save();
    }
}