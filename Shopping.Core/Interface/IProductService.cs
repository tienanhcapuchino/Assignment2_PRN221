using Shopping.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Core.Interface
{
    public interface IProductService
    {
        List<Products> GetAllProducts();
        Products GetProductById(int id);
        List<Products> SearchByName(string name);
        List<Products> SearchByCateId(int cateId);
    }
}
