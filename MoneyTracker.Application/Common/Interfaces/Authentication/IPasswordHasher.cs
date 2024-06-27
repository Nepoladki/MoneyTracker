namespace MoneyTracker.Application.Common.Interfaces.Authentication;

public interface IPasswordHasher
{
    bool HashPassword(string password);
    bool VerifyPassword(string password);
}