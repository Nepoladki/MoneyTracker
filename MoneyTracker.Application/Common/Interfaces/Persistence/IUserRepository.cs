using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    public bool UserExistsById(Guid userId);
    bool Add(User user);
}