using eShop.Domain.Common;

namespace eShop.Domain.Entities
{
    public class ProductCategory : EntityBase<Guid>
    {
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public string? ImageUri { get; private set; }

        public ProductCategory(string title, string? description, string? imageUri)
        {
            Title = title;
            Description = description;
            ImageUri = imageUri;
        }   
    }
}
