namespace eShop.Domain.Common
{
    public abstract class EntityBase<TId> where TId : struct
    {
        public TId Id { get; set; } 
    }
}



