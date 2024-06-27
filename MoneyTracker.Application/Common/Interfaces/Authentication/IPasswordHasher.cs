using ErrorOr;

namespace MoneyTracker.Application.Common.Interfaces.Authentication;

public interface IPasswordHasher
{
    ErrorOr<string> HashPassword(string password);
    ErrorOr<bool> VerifyPassword(string password, string hash);
}