using MoneyTracker.Application.Common.Interfaces.Authentication;

namespace MoneyTracker.Infrastructure.Authentication;

public class JwtSettings : IJwtSettings
{
    public const string SectionName = "JwtSettings";
    public string AccessSecret { get; init; } = null!;
    public int AccessExpiryMinutes { get; init; }
    public string RefreshSecret { get; init; } = null!;
    public string RefreshCookieName { get; init; } = null!;
    public int RefreshExpiryHours { get; init; }
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
}