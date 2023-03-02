using Microsoft.EntityFrameworkCore;
using SignalRAssignment.DataContext;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAssignment.ServiceManager
{
    public class OrderService : IOrderService
    {
        private readonly ShoppingDbContext _shoppingDbContext;
        public OrderService(ShoppingDbContext context)
        {
            _shoppingDbContext = context;
        }

        public async Task<bool> AddOrder(Orders order)
        {
            _shoppingDbContext.Orders.Add(order);
            await _shoppingDbContext.SaveChangesAsync();
            return true;
        }

        public bool DeleteOrder(int cusId)
        {
            var order = _shoppingDbContext.Orders.SingleOrDefault(x => x.OrderId == cusId);
            if (order != null)
            {
                _shoppingDbContext.Orders.Remove(order);
                _shoppingDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Orders> GetAll()
        {
            return _shoppingDbContext.Orders.Include(x => x.Customer).ToList();
        }

        public List<Orders> GetByCusId(int cusId)
        {
            return _shoppingDbContext.Orders.Where(x => x.CustomerId == cusId).ToList();
        }

        public async Task<bool> UpdateOrder(Orders order)
        {
            var entity = await _shoppingDbContext.Orders.SingleOrDefaultAsync(x => x.OrderId == order.OrderId);
            if (entity != null)
            {
                entity.Freight = order.Freight;
                entity.ShipAddress = order.ShipAddress;
                entity.ShippedDate = order.ShippedDate;
                entity.RequiredDate = order.RequiredDate;
                _shoppingDbContext.Orders.Update(entity);
                await _shoppingDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public Orders GetOrderById(int orId)
        {
            return _shoppingDbContext.Orders.Include(x => x.Customer).SingleOrDefault(x => x.OrderId == orId);
        }
    }
}
