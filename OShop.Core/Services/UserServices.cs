using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OShop.Core.Interfaces;
using OShop.DataLayer.Context;
using OShop.DataLayer.Entities;

namespace OShop.Core.Services
{
    public class UserServices : IUser
    {
        private readonly OShopContext _Context;
        public UserServices(OShopContext Context)
        {
            _Context = Context;
        }

        public bool CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public int GetUserCounts()
        {
            return _Context.Users.Count();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
