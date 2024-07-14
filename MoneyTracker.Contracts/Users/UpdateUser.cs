namespace MoneyTracker.Contracts.Users;
public record UpdateUser(
    Guid Id,
    bool IsActive,
    string UserName,
    string Email);

