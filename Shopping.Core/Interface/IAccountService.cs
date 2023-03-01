using Shopping.Core.Entity;
using Shopping.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Core.Interface
{
    public interface IAccountService
    {
        Task<bool> Login(UserLoginModel userLogged);
        Task<bool> IsAdmin(UserLoginModel userLogged);
        Task<bool> IsAccountExist(string username);
        Task<Account> GetAccountByUsername(string username);
        Task<bool> RegisterAccount(Account account);
    }
}
