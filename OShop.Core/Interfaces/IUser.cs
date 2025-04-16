using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OShop.DataLayer.Entities;

namespace OShop.Core.Interfaces
{
    public interface IUser
    {
        bool CreateUser(User user);
        bool UpdateUser(User user);
        IEnumerable<User> GetUsers();
        User GetUser(int userId);
        bool DeleteUser(int userId);
    }
}
