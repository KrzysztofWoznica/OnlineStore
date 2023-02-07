using eShop.Domain.Common;
using eShop.Domain.Entities;

namespace eShop.Domain.Persistence
{
    public interface IUserRepository : IRepository<User, Guid>   
    {
        User? GetUserByEmail(string email);
        
    }
}
