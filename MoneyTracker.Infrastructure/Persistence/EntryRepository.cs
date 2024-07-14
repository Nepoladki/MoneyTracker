using Microsoft.EntityFrameworkCore;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Infrastructure.Persistence;

public class EntryRepository : IEntryRepository
{
    private readonly DataContext _context;

    public EntryRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Entry entry)
    {
        await _context.Entries.AddAsync(entry);
        return await SaveAsync();
    }

    public async Task<bool> EntryExistsAsync(Guid id)
    {
        return await _context.Entries.AnyAsync(t => t.Id == id);
    }

    public async Task<ICollection<Entry>> GetAllEntriesByUserIdAsync(Guid id)
    {
        return await _context.Entries.Where(e => e.UserId == id).OrderBy(x => x.DateTime).ToListAsync();
    }

    public async Task<Entry?> GetEntryByIdAsync(Guid id)
    {
        return await _context.Entries.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<ICollection<Entry>> GetAllEntriesAsync()
    {
        return await _context.Entries.ToListAsync();
    }

    public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() > 0;

    public async Task<bool> DeleteAsync(Entry entry)
    {
        _context.Entries.Remove(entry);
        return await SaveAsync();
    }
}