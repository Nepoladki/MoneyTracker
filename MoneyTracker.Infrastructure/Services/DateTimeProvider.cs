using FoodDelivery.Application.Common.Interfaces.Services;

namespace FoodDelivery.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}