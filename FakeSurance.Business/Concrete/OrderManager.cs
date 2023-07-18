using FakeSurance.Business.Abstract;
using FakeSurance.DataAccess.Abstract;
using FakeSurance.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeSurance.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _OrderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _OrderDal = orderDal;
        }

        public void AddOrder(Order order)
        {
            _OrderDal.Add(order);
        }

        public void DeleteOrder(int id)
        {
            if(_OrderDal.Get(x => x.Id == id) is not null)
            {
                _OrderDal.Delete(x => x.Id == id);
            }
            else
            {
                throw new Exception("Order not found");
            }
        }

        public Order GetOrder(int id)
        {
            if(_OrderDal.Get(x => x.Id == id) is not null)
            {
                return _OrderDal.Get(x => x.Id == id);
            }
            else
            {
                throw new Exception("Order not found");
            }
        }

        public void UpdateOrder(Order order)
        {
            if(_OrderDal.Get(x => x.Id == order.Id) is not null)
            {
                _OrderDal.Update(order);
            }
            else
            {
                throw new Exception("Order not found");
            }
        }

        public List<Order> ListOrder()
        {
            return _OrderDal.GetAll();
        }
    }
}
