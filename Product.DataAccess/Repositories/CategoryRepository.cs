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
        public void AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }
        public void UpdateCategory(Category category)
        {
            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();
        }
        public void RemoveCategory(Category category)
        {
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }
        public List<Category> GetAllCategories()
        {
            return _dbContext.Categories.ToList();
        }
        public Category? GetCategoryById(int id)
        {
            return _dbContext.Categories.FirstOrDefault(i => i.Id == id);
        }

    }
}
