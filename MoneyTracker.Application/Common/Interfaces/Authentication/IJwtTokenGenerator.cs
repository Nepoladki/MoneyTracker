using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken(User user);
}