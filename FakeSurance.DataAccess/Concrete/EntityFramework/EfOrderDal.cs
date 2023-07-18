using FakeSurance.Core.DataAccess.EntityFramework;
using FakeSurance.DataAccess.Abstract;
using FakeSurance.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSurance.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal: EfEntiyRepositoryBase<Order, Context>, IOrderDal
    {
    }
}
