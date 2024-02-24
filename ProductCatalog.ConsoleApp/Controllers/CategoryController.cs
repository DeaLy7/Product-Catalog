using ProductCatalog.BussinessLogic.Interface;
using ProductCatalog.DataAccess.Data.Models;

namespace ProductCatalog.ConsoleApp.Controllers
{
    public class CategoryController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public void AddCategory(Category category)
        {
            _categoryService.AddCategory(category);
        }
        public void UpdateCategory(Category category)
        {
            _categoryService.UpdateCategory(category);
        }
        public void RemoveCategory(Category category)
        {
            _categoryService.RemoveCategory(category);
        }
        public List<Category> GetAllCategories()
        {
            return _categoryService.GetAllCategories();
        }
        public Category? GetCategoryById(int id)
        {
            return _categoryService.GetCategoryById(id);
        }
    }
}
