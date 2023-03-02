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
    public class CategoriesService : ICategoriesService
    {
        private readonly ShoppingDbContext _context;
        public CategoriesService(ShoppingDbContext context)
        {
            _context = context;
        }
        public List<Categories> GetAllCategoriesName()
        {
            return _context.Categories.ToList();
        }
    }
}
