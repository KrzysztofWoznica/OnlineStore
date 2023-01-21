using FluentValidation;
using Microsoft.Extensions.DependencyInjection;



namespace eShop.Application.Common.Validation.Factories
{
    public class ValidatorFactory : IValidatorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider; 
        }

        public IValidator<T> GetValidator<T>() => _serviceProvider.GetRequiredService<IValidator<T>>();

        public IValidator<T> GetValidator<T>(T entity) => this.GetValidator<T>();
     
    }
}
