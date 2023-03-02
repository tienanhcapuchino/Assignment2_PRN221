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
    public class SuplierService : ISuplierService
    {
        private readonly ShoppingDbContext _context;
        public SuplierService(ShoppingDbContext context)
        {
            _context = context;
        }

        public List<Suppliers> GetAll()
        {
            return _context.Suppliers.ToList();
        }
    }
}
