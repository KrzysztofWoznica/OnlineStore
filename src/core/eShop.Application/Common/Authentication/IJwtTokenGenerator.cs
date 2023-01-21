using eShop.Domain.Entities;


namespace eShop.Application.Common.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user); 
    }
}
