namespace MoneyTracker.Contracts.Authentication;

public record RegisterRequest
(
    string UserName,
    string Email,
    string Password,
    string PasswordCopy
);