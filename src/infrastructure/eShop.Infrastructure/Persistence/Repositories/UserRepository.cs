using eShop.Domain.Persistence;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Infrastructure.Persistence.Data;

namespace eShop.Infrastructure.Persistence.Repositories
{
    internal class UserRepository : EFRepository<User, Guid>, IUserRepository
    {
        //static private readonly List<User> _users = new();

        UserRepository(ApplicationDbContext context): base(context)
        {

        }

        public User? GetUserByEmail(string email)
        {
            return GetSet().SingleOrDefault(u => u.Email == email);
        }
    }
}
