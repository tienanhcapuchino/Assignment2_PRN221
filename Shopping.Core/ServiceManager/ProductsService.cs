using Microsoft.EntityFrameworkCore;
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
    public class ProductsService : IProductService
    {
        private readonly ShoppingDbContext _context;
        public ProductsService(ShoppingDbContext context)
        {
            _context = context;
        }
        public List<Products> GetAllProducts()
        {
            return _context.Products.Include(x => x.Category).Include(x => x.Supplier).ToList();
        }

        public Products GetProductById(int id)
        {
            return _context.Products.Where(x => x.ProductId == id).SingleOrDefault();
        }

        public List<Products> SearchByCateId(int cateId)
        {
            return _context.Products.Include(x => x.Category).Include(x => x.Supplier).Where(x => x.CategoryId == cateId).ToList();
        }

        public List<Products> SearchByName(string name)
        {
            return _context.Products.Include(x => x.Supplier).Include(x => x.Category).Where(x => x.ProductName.Contains(name)).ToList();
        }
    }
}
