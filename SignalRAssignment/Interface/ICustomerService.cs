using SignalRAssignment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAssignment.Interface
{
    public interface ICustomerService
    {
        Task<bool> UpdateProfile(Customers cus);
        Task<bool> ChangePassword(int cusId, string password);
        List<Customers> GetAllCustomers();
        Task<bool> AddNewCus(Customers cus);
        Task<bool> Login(string phone, string password);
        Customers GetCustomerByPhone(string phone);
        Customers GetCustomerById(int cusId);
    }
}
