using FakeSurance.Core.DataAccess.Abstract;
using FakeSurance.Core.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSurance.DataAccess.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {
    }
}
