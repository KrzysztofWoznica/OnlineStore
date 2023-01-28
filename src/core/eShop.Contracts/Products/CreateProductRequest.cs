

namespace eShop.Contracts.Products
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price{ get; set; }
        public string ImageUri { get; set; }
        public Guid CategoryId { get; set; }
    }
}
