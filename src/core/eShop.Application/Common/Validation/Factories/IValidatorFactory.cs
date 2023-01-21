using FluentValidation;


namespace eShop.Application.Common.Validation.Factories
{
    public interface IValidatorFactory
    {
        IValidator<T> GetValidator<T>();
        IValidator<T> GetValidator<T>(T entity);
    }
}
