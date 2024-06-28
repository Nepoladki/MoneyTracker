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

    public bool Add(User user)
    {
        _context.Users.Add(user);
        return Save();
    }

    public User? GetUserByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }

    public bool Save() => _context.SaveChanges() > 0;
}
