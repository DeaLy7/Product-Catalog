using ProductCatalog.DataAccess.Data;
using ProductCatalog.DataAccess.Data.Models;
using ProductCatalog.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;
        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddProduct(Product product)
        {
            _dbContext.Add(product);
            _dbContext.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            _dbContext.Update(product);
            _dbContext.SaveChanges();
        }
        public void RemoveProduct(Product product)
        {
            _dbContext.Remove(product); 
            _dbContext.SaveChanges();
        }
        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }
        public Product? GetProductById(int id)
        {
            return _dbContext.Products.Find(id);
        }
    }
}
