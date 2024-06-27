using MoneyTracker.Application.Common.Interfaces.Services;

namespace MoneyTracker.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}