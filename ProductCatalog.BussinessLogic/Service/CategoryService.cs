using ProductCatalog.DataAccess.Data.Models;
using ProductCatalog.DataAccess.Data;
using ProductCatalog.DataAccess.Repositories;
using ProductCatalog.DataAccess.Interface;
using ProductCatalog.BussinessLogic.Interface;
using Microsoft.EntityFrameworkCore;

namespace ProductCatalog.BussinessLogic.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categorytRepository;
        public CategoryService(ICategoryRepository categorytRepository)
        {
            _categorytRepository = categorytRepository;
        }
        public void AddCategory(Product category)
        {
            _categorytRepository.AddCategory(category);
        }
        public void UpdateCategory(Product category)
        {
            _categorytRepository.UpdateCategory(category);
        }
        public void RemoveCategory(Product category)
        {
            _categorytRepository.RemoveCategory(category);
        }
        public List<Product> GetAllCategories()
        {
            return _categorytRepository.GetAllCategories();
        }
        public Product? GetCategoryById(int id)
        {
            return _categorytRepository.GetCategoryById(id);
        }
    }
}
