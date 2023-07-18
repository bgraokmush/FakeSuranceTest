using FakeSurance.Business.Abstract;
using FakeSurance.Core.Entites.Concrete;
using FakeSurance.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSurance.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _UserDal;

        public UserManager(IUserDal userDal)
        {
            _UserDal = userDal;
        }

        public void AddUser(User user)
        {
            _UserDal.Add(user);
        }

        public void DeleteUser(int id)
        {
            if(_UserDal.Get(u => u.Id == id) is not null)
            {
                _UserDal.Delete(u => u.Id == id);
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public User GetUser(int id)
        {
            if(_UserDal.Get(x => x.Id == id) is not null)
            {
                return _UserDal.Get(x => x.Id == id);
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public User GetUserByName(string name)
        {
            if(_UserDal.Get(x => x.Name == name) is not null)
            {
                return _UserDal.Get(x => x.Name == name);
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public void UpdateUser(User user)
        {
            if (_UserDal.Get(x => x.Id == user.Id) is not null)
            {
                _UserDal.Update(user);
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        public List<User> UserList()
        {
            return _UserDal.GetAll();
        }
    }
}
