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
        public void AddCategory(Product category)
        {
            _categoryService.AddCategory(category);
        }
        public void UpdateCategory(Product category)
        {
            _categoryService.UpdateCategory(category);
        }
        public void RemoveCategory(Product category)
        {
            _categoryService.RemoveCategory(category);
        }
        public List<Product> GetAllCategories()
        {
            return _categoryService.GetAllCategories();
        }
        public Product? GetCategoryById(int id)
        {
            return _categoryService.GetCategoryById(id);
        }
    }
}
