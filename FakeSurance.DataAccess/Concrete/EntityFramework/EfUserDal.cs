using FakeSurance.Core.DataAccess.EntityFramework;
using FakeSurance.Core.Entites.Concrete;
using FakeSurance.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSurance.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal: EfEntiyRepositoryBase<User, Context>, IUserDal
    {
    }
}
