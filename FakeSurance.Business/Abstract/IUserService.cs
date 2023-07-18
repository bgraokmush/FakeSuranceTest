using FakeSurance.Core.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSurance.Business.Abstract
{
    public interface IUserService
    {
        List<User> UserList();
        User GetUser(int id);
        User GetUserByName(string name);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
