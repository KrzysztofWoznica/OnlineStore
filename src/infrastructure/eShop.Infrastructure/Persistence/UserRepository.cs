using eShop.Domain.Persistence;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Persistence
{
    internal class UserRepository : Repository<User, Guid>, IUserRepository
    {
        //static private readonly List<User> _users = new();

        public void AddUser(User user)
        {
            _entities.Add(user);    
        }

        public User? GetUserByEmail(string email)
        {
            return _entities.SingleOrDefault(u => u.Email == email);  
        }
    }
}
