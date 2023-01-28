using eShop.Contracts.Products;
using FluentValidation;


namespace eShop.Application.Services.Products.Validators
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.ImageUri).NotEmpty();
        }
    }
}
