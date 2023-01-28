namespace eShop.Application.Interfaces.common
{
    public enum ServiceResponseStatus
    {
        Success,       
        ValidationError,
        NotFound,
        Forbidden,
        Conflict,
        BadRequest
    }
}
