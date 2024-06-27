using MoneyTracker.Domain.Entities;

namespace MoneyTracker.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}