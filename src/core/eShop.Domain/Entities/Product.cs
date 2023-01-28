using eShop.Domain.Common;

namespace eShop.Domain.Entities
{
    public class Product : EntityBase<Guid>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; } 
        public string ImageUri { get; set; } = null!;
        public Guid CategoryId { get; set; } 
        public ProductCategory Category { get; set; } = null!;



    }
}
