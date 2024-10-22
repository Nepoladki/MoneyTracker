namespace MoneyTracker.Application.Users.Common;

public record UserDto(
    Guid Id,
    bool IsActive,
    string UserName,
    string FirstName,
    string LastName,
    string Email);