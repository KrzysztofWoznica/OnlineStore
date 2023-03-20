using eShop.Application.Common.Paging;
using eShop.Application.Interfaces.common.Paging;
using eShop.Application.Services.Products.Repositories;
using eShop.Domain.Entities;
using eShop.Infrastructure.Persistence.Data;
using eShop.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;


namespace eShop.Infrastructure.Persistence.Repositories
{
    internal class ProductRepository : EFRepository<Product, Guid>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<PagedList<Product>> GetAllPagedAsync(PagingParameters parameters)
        {
            var query = this.GetSet()
                .AsNoTracking();

            var totalResults = await query.CountAsync();

            var data = await query
                .GetPage(parameters)
                .ToListAsync();

            return new PagedList<Product>()
            {
                PageNumber = parameters.PageNumber,
                PageSize = parameters.PageSize,
                TotalCount = totalResults,
                Results = data
            };
        }
    }
}
