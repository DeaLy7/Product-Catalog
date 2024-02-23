using ProductCatalog.DataAccess.Data.Models;
using ProductCatalog.DataAccess.Data;
using ProductCatalog.DataAccess.Interface;

namespace ProductCatalog.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductDbContext _dbContext;
        public CategoryRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddCategory(Product category)
        {
            _dbContext.Add(category);
            _dbContext.SaveChanges();
        }
        public void UpdateCategory(Product category)
        {
            _dbContext.Update(category);
            _dbContext.SaveChanges();
        }
        public void RemoveCategory(Product category)
        {
            _dbContext.Remove(category);
            _dbContext.SaveChanges();
        }
        public List<Product> GetAllCategories()
        {
            return _dbContext.Products.ToList();
        }
        public Product? GetCategoryById(int id)
        {
            return _dbContext.Products.Find(id);
        }

    }
}
