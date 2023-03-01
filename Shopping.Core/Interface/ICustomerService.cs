using Shopping.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Core.Interface
{
    public interface ICustomerService
    {
        Task<bool> UpdateProfile(Customers cus);
        Task<bool> ChangePassword(int cusId, string password);
        List<Customers> GetAllCustomers();
        Task<bool> AddNewCus(Customers cus);
    }
}
