using SignalRAssignment.Entity;
using SignalRAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAssignment.Interface
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
