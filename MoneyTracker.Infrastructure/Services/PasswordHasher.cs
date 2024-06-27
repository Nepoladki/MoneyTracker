using ErrorOr;
using MoneyTracker.Application.Common.Interfaces.Authentication;
using MoneyTracker.Domain.Common.Errors;

namespace MoneyTracker.Infrastructure.Services;

public class PasswordHasher : IPasswordHasher
{
    public ErrorOr<string> HashPassword(string password)
    {
        try
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }
        catch (Exception)
        {
            return Errors.Authentication.HashingError;
        }
    }

    public ErrorOr<bool> VerifyPassword(string password, string hash)
    {
        try
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
        }
        catch (Exception)
        {
            return Errors.Authentication.VeryfingPasswordHashError;
        }
    }
}