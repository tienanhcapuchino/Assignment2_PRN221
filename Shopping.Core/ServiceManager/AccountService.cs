using Microsoft.EntityFrameworkCore;
using Shopping.Core.DataContext;
using Shopping.Core.Entity;
using Shopping.Core.Interface;
using Shopping.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Core.ServiceManager
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
            && x.Password == userLogged.Password
            && x.Type == 2).FirstOrDefaultAsync();
            if (user != null) return true;
            return false;
        }
    }
}
