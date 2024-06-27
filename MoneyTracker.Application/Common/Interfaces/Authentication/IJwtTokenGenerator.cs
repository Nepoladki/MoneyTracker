using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}