using eShop.Application.Common.Persistence.Repositories;
using eShop.Domain.Entities;

namespace eShop.Application.Services.Authentication.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        User? GetUserByEmail(string email);

    }
}
