using eShop.Application.Common.Paging;
using eShop.Application.Common.Persistence.Repositories;
using eShop.Application.Interfaces.common.Paging;
using eShop.Domain.Entities;


namespace eShop.Application.Services.Products.Repositories
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<PagedList<Product>> GetAllPagedAsync(PagingParameters parameters);
    }
}
