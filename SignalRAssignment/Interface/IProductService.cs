using SignalRAssignment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAssignment.Interface
{
    public interface IProductService
    {
        List<Products> GetAllProducts();
        Products GetProductById(int id);
        List<Products> SearchByName(string name);
        List<Products> SearchByCateId(int cateId);
        Task<bool> AddProduct(Products pro);
        bool DeleteProduct(int id);
        Task<bool> UpdateProduct(Products pro);
    }
}
