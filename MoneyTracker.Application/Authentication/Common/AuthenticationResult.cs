using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);