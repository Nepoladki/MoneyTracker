namespace MoneyTracker.Contracts.Users;
public record UpdateUserRequest(
    Guid Id,
    bool IsActive,
    string UserName,
    string FirstName,
    string LastName,
    string Email);

