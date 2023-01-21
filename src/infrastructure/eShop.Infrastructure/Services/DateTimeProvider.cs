using eShop.Application.Common.Services;


namespace eShop.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;  
    }
}
