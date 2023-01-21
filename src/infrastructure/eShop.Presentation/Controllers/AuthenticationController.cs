using Microsoft.AspNetCore.Mvc;
using eShop.Contracts.Authentication;
//using eShop.Application.Services.Authentication;
using eShop.Application.Interfaces;

namespace eShop.Api.Controllers
{    
    [Route("api/auth")]      
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {            
            var response = await _authenticationService.Register(request);
            
            return ActionResultFromServiceResponse(response);   


            /*
            ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(
                request.FirstName,
                request.LastName, 
                request.Email,
                request.Password);           

            return authResult.Match(
                authResult => Ok(new AuthenticationResponse(
                    authResult.User.Id,
                    authResult.User.FirstName,
                    authResult.User.LastName,
                    authResult.User.Email,
                    authResult.Token)),
                errors => Problem(errors));*/

            /*
            var response = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);*/
            //return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            return Ok();
            /*
            var authResult = _authenticationService.Login(  
                request.Email,
                request.Password);

            return authResult.Match(
                authResult => Ok(new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token)),
                errors => Problem(errors));*/

            /*
            var response = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token);
            return Ok(response); */          
        }
    }
}
