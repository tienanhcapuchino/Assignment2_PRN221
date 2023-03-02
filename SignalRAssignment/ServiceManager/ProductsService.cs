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
    public class ProductsService : IProductService
    {
        private readonly ShoppingDbContext _context;
        public ProductsService(ShoppingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProduct(Products pro)
        {
            _context.Products.Add(pro);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var pro = _context.Products.SingleOrDefault(x => x.ProductId == id);
            if (pro != null)
            {
                _context.Products.Remove(pro);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Products> GetAllProducts()
        {
            return _context.Products.Include(x => x.Category).Include(x => x.Supplier).ToList();
        }

        public Products GetProductById(int id)
        {
            return _context.Products.Where(x => x.ProductId == id).Include(x => x.Category).Include(x => x.Supplier).SingleOrDefault();
        }

        public List<Products> SearchByCateId(int cateId)
        {
            return _context.Products.Include(x => x.Category).Include(x => x.Supplier).Where(x => x.CategoryId == cateId).ToList();
        }

        public List<Products> SearchByName(string name)
        {
            return _context.Products.Include(x => x.Supplier).Include(x => x.Category).Where(x => x.ProductName.Contains(name)).ToList();
        }

        public async Task<bool> UpdateProduct(Products pro)
        {
            var model = await _context.Products.SingleOrDefaultAsync(x => x.ProductId == pro.ProductId);
            if (model != null)
            {
                model.SupplierId = pro.SupplierId;
                model.CategoryId = pro.CategoryId;
                model.ProductName = pro.ProductName;
                model.QuantityPerUnit = pro.QuantityPerUnit;
                model.UnitPrice = pro.UnitPrice;
                _context.Products.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
