using Shopping.Core.DataContext;
using Shopping.Core.Entity;
using Shopping.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Core.ServiceManager
{
    public class OrderService : IOrderService
    {
        private readonly ShoppingDbContext _shoppingDbContext;
        public OrderService(ShoppingDbContext context)
        {
            _shoppingDbContext = context;
        }
        public List<Orders> GetByCusId(int cusId)
        {
            return _shoppingDbContext.Orders.Where(x => x.CustomerId == cusId).ToList();
        }
    }
}
