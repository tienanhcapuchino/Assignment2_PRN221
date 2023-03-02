using SignalRAssignment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAssignment.Interface
{
    public interface ICategoriesService
    {
        List<Categories> GetAllCategoriesName();
        Task<bool> AddNew(Categories category);
        bool DeleteCate(int cateId);
        Task<bool> UpdateCate(Categories category);
        Categories GetCategories(int cateId);
    }
}
