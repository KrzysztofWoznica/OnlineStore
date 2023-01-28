using eShop.Domain.Common;
using eShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Persistence
{
    public interface IUserRepository : IRepository<User, Guid>   
    {
        User? GetUserByEmail(string email);
        void AddUser(User user);
    }
}
