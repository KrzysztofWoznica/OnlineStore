using eShop.Application.Interfaces.common;
using eShop.Contracts.Products;


namespace eShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponse<ProductDto>> GetProductAsync(Guid Id);
        Task<ServiceResponse<ProductDto>> CreateProductAsync(CreateProductRequest request);
        Task<ServiceResponse> DeleteProductAsync(Guid id);
    }
}
