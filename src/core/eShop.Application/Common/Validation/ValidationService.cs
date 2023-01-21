using eShop.Application.Common.Validation.Factories;
using FluentValidation.Results;



namespace eShop.Application.Common.Validation
{
    public class ValidationService : IValidationService
    {
        private readonly IValidatorFactory _validatorFactory;   

        public ValidationService(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }   

        public async Task<ValidationResult> ValidateAsync<T>(T entity)
        {
            var validator = _validatorFactory.GetValidator(entity);
            return await validator.ValidateAsync(entity);
        }
    }
}
