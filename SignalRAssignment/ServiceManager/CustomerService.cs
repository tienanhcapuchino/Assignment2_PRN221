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
    public class CustomerService : ICustomerService
    {
        private readonly ShoppingDbContext _context;
        public CustomerService(ShoppingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewCus(Customers cus)
        {
            _context.Customers.Add(cus);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangePassword(int cusId, string password)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(x => x.CustomerId == cusId);
            if (customer != null)
            {
                customer.Password = password;
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public List<Customers> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customers GetCustomerById(int cusId)
        {
            return _context.Customers.SingleOrDefault(x => x.CustomerId == cusId);
        }

        public Customers GetCustomerByPhone(string phone)
        {
            return _context.Customers.SingleOrDefault(x => x.Phone == phone);
        }

        public async Task<bool> Login(string phone, string password)
        {
            var cus = await _context.Customers.SingleOrDefaultAsync(x => x.Password == password && x.Phone == phone);
            if (cus != null) return true;
            return false;
        }

        public async Task<bool> UpdateProfile(Customers cus)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(x => x.CustomerId == cus.CustomerId);
            if (customer != null)
            {
                customer.Address = cus.Address;
                customer.Phone = cus.Phone;
                customer.ContactName = customer.ContactName;
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
