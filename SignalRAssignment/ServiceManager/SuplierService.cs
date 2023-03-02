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
    public class SuplierService : ISuplierService
    {
        private readonly ShoppingDbContext _context;
        public SuplierService(ShoppingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNew(Suppliers supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Delete(int supId)
        {
            var sup = _context.Suppliers.SingleOrDefault(x => x.SupplierId == supId);
            if (sup != null)
            {
                _context.Suppliers.Remove(sup);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Suppliers> GetAll()
        {
            return _context.Suppliers.ToList();
        }

        public Suppliers GetSuppliers(int supId)
        {
            return _context.Suppliers.SingleOrDefault(x => x.SupplierId == supId);
        }

        public async Task<bool> Update(Suppliers suppliers)
        {
            var sup = await _context.Suppliers.SingleOrDefaultAsync(x => x.SupplierId == suppliers.SupplierId);
            if (sup != null)
            {
                sup.Address = suppliers.Address;
                sup.CompanyName = suppliers.CompanyName;
                sup.Phone = suppliers.Phone;
                _context.Suppliers.Update(sup);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
