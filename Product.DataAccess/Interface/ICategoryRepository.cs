using ProductCatalog.DataAccess.Data.Models;

namespace ProductCatalog.DataAccess.Interface
{
    public interface ICategoryRepository
    {
        void AddCategory(Product category);
        void RemoveCategory(Product category);
        void UpdateCategory(Product category);
        List<Product> GetAllCategories();
        Product? GetCategoryById(int id);

    }
}
