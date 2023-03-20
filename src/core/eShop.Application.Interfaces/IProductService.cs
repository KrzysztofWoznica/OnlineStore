using eShop.Application.Interfaces.common;
using eShop.Application.Interfaces.common.Paging;
using eShop.Contracts.Products;


namespace eShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponse<PagedList<ProductDto>>> GetProductsAsync(FromQueryParameters? parameters);
        Task<ServiceResponse<ProductDto>> GetProductAsync(Guid Id);
        Task<ServiceResponse<ProductDto>> CreateProductAsync(CreateProductRequest request);
        Task<ServiceResponse> DeleteProductAsync(Guid id);
    }
}
