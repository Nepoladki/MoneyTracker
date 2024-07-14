using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    public Task<User?> GetUserByIdAsync(Guid id);
    public Task<User?> GetUserByEmailAsync(string email);
    public Task<ICollection<User>> GetAllUsersAsync();
    public Task<bool> UserExistsByIdAsync(Guid userId);
    public Task<bool> AddAsync(User user);
    public Task<bool> DeleteAsync(User user);
    public Task<bool> SaveAsync();
}