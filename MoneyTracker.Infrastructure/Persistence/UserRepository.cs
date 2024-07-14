using Microsoft.EntityFrameworkCore;
using MoneyTracker.Application.Common.Interfaces.Persistence;
using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext dbContext)
    {
        _context = dbContext;
    }
    
    public async Task<bool> UserExistsByIdAsync(Guid userId)
    {
        return await _context.Users.AnyAsync(u => u.Id == userId);
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<bool> AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        return await SaveAsync();
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<ICollection<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() > 0;

    public async Task<bool> DeleteAsync(User user)
    {
        _context.Users.Remove(user);
        return await SaveAsync();
    }
}
