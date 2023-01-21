using eShop.Application.Common.Validation;
using eShop.Application.Common.Validation.Factories;
using eShop.Application.Interfaces;
using eShop.Application.Services.Authentication;
using eShop.Application.Validators.Authentication;
using eShop.Contracts.Authentication;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using IValidatorFactory = eShop.Application.Common.Validation.Factories.IValidatorFactory;

namespace eShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IValidationService, ValidationService>()
                .AddScoped<IValidatorFactory, ValidatorFactory>();

            services.RegisterScopedValidator<RegisterRequest, RegisterRequestValidator>();

            return services;
        }


        public static IServiceCollection RegisterScopedValidator<T, TValidator>(this IServiceCollection serviceCollection) where TValidator : class, IValidator<T>
            => serviceCollection.AddScoped<IValidator<T>, TValidator>();
        
    }
}
