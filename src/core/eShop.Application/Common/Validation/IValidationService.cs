using FluentValidation.Results;


namespace eShop.Application.Common.Validation
{
    public interface IValidationService
    {
        Task<ValidationResult> ValidateAsync<T>(T entity);
    }
}
