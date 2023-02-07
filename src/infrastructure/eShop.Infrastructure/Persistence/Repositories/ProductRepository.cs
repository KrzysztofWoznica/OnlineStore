using eShop.Domain.Entities;
using eShop.Domain.Persistence;
using eShop.Infrastructure.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Persistence.Repositories
{
    internal class ProductRepository : EFRepository<Product, Guid>, IProductRepository
    {
        ProductRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
