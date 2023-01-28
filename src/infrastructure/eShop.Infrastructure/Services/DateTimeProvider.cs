using eShop.Application.Common.Services;


namespace eShop.Infrastructure.Services
{
    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;  
    }
}
