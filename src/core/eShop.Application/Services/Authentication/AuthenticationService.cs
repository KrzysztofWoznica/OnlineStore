using eShop.Application.Common.Authentication;
using eShop.Application.Common.Interfaces.Persistence;
using eShop.Application.Common.Validation;
using eShop.Application.Interfaces;
using eShop.Application.Interfaces.common;
using eShop.Contracts.Authentication;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IValidationService _validationService;


        public AuthenticationService(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository,
            IValidationService validationService)
        {
            _jwtTokenGenerator = jwtTokenGenerator; 
            _userRepository = userRepository;   
            _validationService = validationService;
        }
        /*
        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
           
            if(_userRepository.GetUserByEmail(email) != null)
            {
                return Errors.User.DuplicateEmail;
            }

            var newUser = new User { 
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.AddUser(newUser);                     

            var token = _jwtTokenGenerator.GenerateToken(newUser);

            return new AuthenticationResult(
                newUser,
                token);
        }

        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if(user.Password != password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);


            return new AuthenticationResult(
                user,
                token);
        }*/

        public async Task<ServiceResponse<AuthenticationResponse>> Register(RegisterRequest registerRequest)
        {                    
            var validationResult = await _validationService.ValidateAsync(registerRequest);
            if (!validationResult.IsValid)
                return new ServiceResponse<AuthenticationResponse>(validationResult);            

             //
            if (_userRepository.GetUserByEmail(registerRequest.Email) != null)
            {                
                return new ServiceResponse<AuthenticationResponse>(ServiceResponseStatus.Conflict);
            }

            var newUser = new User
            {
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Email = registerRequest.Email,
                Password = registerRequest.Password
            };

            _userRepository.AddUser(newUser);

            var token = _jwtTokenGenerator.GenerateToken(newUser);        

            return new ServiceResponse<AuthenticationResponse>(
                new AuthenticationResponse(
                    newUser.Id,
                    newUser.FirstName,
                    newUser.LastName,
                    newUser.Email,
                    token
                ));
        }

        public Task<ServiceResponse<AuthenticationResponse>> Login(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }
    }
}
