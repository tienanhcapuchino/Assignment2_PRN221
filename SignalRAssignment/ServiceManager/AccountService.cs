using Microsoft.EntityFrameworkCore;
using SignalRAssignment.DataContext;
using SignalRAssignment.Entity;
using SignalRAssignment.Interface;
using SignalRAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAssignment.ServiceManager
{
    public class AccountService : IAccountService
    {
        private readonly ShoppingDbContext _context;
        public AccountService(ShoppingDbContext context) 
        {
            _context = context;
        }

        public async Task<Account> GetAccountByUsername(string username)
        {
            return await _context.Accounts.SingleOrDefaultAsync(x => x.Username == username);
        }

        public async Task<bool> IsAccountExist(string username)
        {
            var user = await _context.Accounts.Where(x => x.Username == username).FirstOrDefaultAsync();
            if (user != null) return true;
            return false;
        }

        public async Task<bool> IsAdmin(UserLoginModel userLogged)
        {
            var user = await _context.Accounts.Where(x => x.Username == userLogged.Username
            && x.Password == userLogged.Password
            && x.Type == 1).FirstOrDefaultAsync();
            if (user != null) return true;
            return false;
        }

        public async Task<bool> Login(UserLoginModel userLogged)
        {
            var user = await _context.Accounts.Where(x => x.Username == userLogged.Username 
            && x.Password == userLogged.Password).FirstOrDefaultAsync();
            if (user != null) return true;
            return false;
        }

        public async Task<bool> RegisterAccount(Account account)
        {
            var acc = await _context.Accounts.SingleOrDefaultAsync(x => x.Username == account.Username);
            if (acc != null) return false;
            account.Type = 2;
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
