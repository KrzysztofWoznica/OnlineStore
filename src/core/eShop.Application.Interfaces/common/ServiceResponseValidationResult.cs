namespace eShop.Application.Interfaces.common
{
    public class ServiceResponseValidationResult
    {
        public string Key { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string ErrorCode { get; set; } = null!;
    }
}
