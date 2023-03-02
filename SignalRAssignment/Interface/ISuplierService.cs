using SignalRAssignment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAssignment.Interface
{
    public interface ISuplierService
    {
        List<Suppliers> GetAll();
        Task<bool> AddNew(Suppliers supplier);
        Task<bool> Update(Suppliers suppliers);
        bool Delete(int supId);
        Suppliers GetSuppliers(int supId);
    }
}
