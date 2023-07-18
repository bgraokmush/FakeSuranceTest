
using FakeSurance.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSurance.Business.Abstract
{
    public interface IPdfService
    {
        public byte[] GeneratePdfFromTable(Order order);
    }
}
