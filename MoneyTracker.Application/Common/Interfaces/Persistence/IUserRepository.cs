using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}