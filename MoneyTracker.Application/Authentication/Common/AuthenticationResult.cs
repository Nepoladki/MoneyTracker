using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);