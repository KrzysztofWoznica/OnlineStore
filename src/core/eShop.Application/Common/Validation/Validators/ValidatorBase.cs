using eShop.Application.Common.Validation.Extensions;
using FluentValidation;
using System.Linq.Expressions;
using IValidatorFactory = eShop.Application.Common.Validation.Factories.IValidatorFactory;

namespace eShop.Application.Common.Validation.Validators
{
    public abstract class ValidatorBase<T> : AbstractValidator<T>        
    {
        private readonly IValidatorFactory _validatorFactory;

        public ValidatorBase(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;   
        }

        protected IRuleBuilder<T, TProperty?> SetValidator<TProperty>(Expression<Func<T, TProperty>> expression) where TProperty : class
            => this.RuleFor(expression).SetValidatorWithFactory(this._validatorFactory);
    }
}
