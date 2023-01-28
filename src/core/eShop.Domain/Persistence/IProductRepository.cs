using eShop.Domain.Common;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Persistence
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        
    }
}
