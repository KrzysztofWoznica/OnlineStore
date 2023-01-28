using eShop.Domain.Entities;
using eShop.Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Persistence
{
    internal class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
    }
}
