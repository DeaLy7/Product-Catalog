using ProductCatalog.DataAccess.Data.Models;

namespace ProductCatalog.DataAccess.Interface
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        void RemoveCategory(Category category);
        void UpdateCategory(Category category);
        List<Category> GetAllCategories();
        Category? GetCategoryById(int id);

    }
}
