using ProductCatalog.DataAccess.Data.Models;

namespace ProductCatalog.BussinessLogic.Interface
{
    public interface IProductService
    {
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        void UpdateProduct(Product product);
        List<Product> GetAllProducts();
        Product? GetProductById(int id);
    }
}
