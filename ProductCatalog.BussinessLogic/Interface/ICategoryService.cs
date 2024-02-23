using ProductCatalog.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BussinessLogic.Interface
{
    public interface ICategoryService
    {
        void AddCategory(Product category);
        void RemoveCategory(Product category);
        void UpdateCategory(Product category);
        List<Product> GetAllCategories();
        Product? GetCategoryById(int id);
    }
}
