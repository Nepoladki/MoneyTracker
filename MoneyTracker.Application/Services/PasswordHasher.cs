using MoneyTracker.Application.Common.Interfaces.Authentication;
using BCrypt;

namespace MoneyTracker.Application.Services;

public class PasswordHasher : IPasswordHasher
{
    public bool HashPassword(string password)
    {
        BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password)
    {
        throw new NotImplementedException();
    }
}