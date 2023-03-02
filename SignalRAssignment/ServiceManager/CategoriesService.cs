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
    public class CategoriesService : ICategoriesService
    {
        private readonly ShoppingDbContext _context;
        public CategoriesService(ShoppingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNew(Categories category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return true;
        }
        public Categories GetCategories(int cateId)
        {
            return _context.Categories.SingleOrDefault(x => x.CategoryId == cateId);
        }
        public bool DeleteCate(int cateId)
        {
            var cate = _context.Categories.SingleOrDefault(x => x.CategoryId == cateId);
            if (cate != null)
            {
                _context.Categories.Remove(cate);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Categories> GetAllCategoriesName()
        {
            return _context.Categories.ToList();
        }

        public async Task<bool> UpdateCate(Categories category)
        {
            var cate = await _context.Categories.SingleOrDefaultAsync(x => x.CategoryId == category.CategoryId);
            if (cate != null)
            {
                cate.Description = category.Description;
                cate.CategoryName = category.CategoryName;
                _context.Categories.Update(cate);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
