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
        public void AddCategory(Category category)
        {
            _categorytRepository.AddCategory(category);
        }
        public void UpdateCategory(Category category)
        {
            _categorytRepository.UpdateCategory(category);
        }
        public void RemoveCategory(Category category)
        {
            _categorytRepository.RemoveCategory(category);
        }
        public List<Category> GetAllCategories()
        {
            return _categorytRepository.GetAllCategories();
        }
        public Category? GetCategoryById(int id)
        {
            return _categorytRepository.GetCategoryById(id);
        }
    }
}
