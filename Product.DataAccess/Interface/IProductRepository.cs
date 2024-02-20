using ProductCatalog.DataAccess.Data.Models;

namespace ProductCatalog.DataAccess.Interface
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        void UpdateProduct(Product product);
        List<Product> GetAllProducts();
        Product? GetProductById (int id);
    }
}
