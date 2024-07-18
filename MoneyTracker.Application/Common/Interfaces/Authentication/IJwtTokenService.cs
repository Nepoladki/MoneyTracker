using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Interfaces.Authentication;

public interface IJwtTokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken(User user);
}