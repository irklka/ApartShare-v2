using ApartShare.Application.Interfaces.Services;

namespace ApartShare.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
