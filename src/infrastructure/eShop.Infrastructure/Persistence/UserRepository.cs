using eShop.Application.Common.Interfaces.Persistence;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        static private readonly List<User> _users = new();

        public void AddUser(User user)
        {
            _users.Add(user);    
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);  
        }
    }
}
