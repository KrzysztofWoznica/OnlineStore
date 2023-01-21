using FluentValidation;
using IValidatorFactory = eShop.Application.Common.Validation.Factories.IValidatorFactory;

namespace eShop.Application.Common.Validation.Extensions
{
    public static class ValidationExtensions
    {
        public static IRuleBuilder<T, TProperty> SetValidatorWithFactory<T, TProperty>(this IRuleBuilder<T, TProperty> rule, IValidatorFactory factory)
            => rule.SetValidator(_ => factory.GetValidator<TProperty>());
    }
}
