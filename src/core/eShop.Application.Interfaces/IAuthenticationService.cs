using eShop.Contracts.Authentication;
using eShop.Application.Interfaces.common;


namespace eShop.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ServiceResponse<AuthenticationResponse>> Register(RegisterRequest registerRequest);
        Task<ServiceResponse<AuthenticationResponse>> Login(LoginRequest loginRequest);
    }
}
