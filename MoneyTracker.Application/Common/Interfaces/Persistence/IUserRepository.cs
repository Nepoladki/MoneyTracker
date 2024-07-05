using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    public User? GetUserById(Guid id);
    public User? GetUserByEmail(string email);
    public ICollection<User> GetAllUsers();
    public bool UserExistsById(Guid userId);
    public bool Add(User user);
    public bool Delete(User user);
}