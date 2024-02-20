using Microsoft.EntityFrameworkCore;
using ProductCatalog.BussinessLogic.Interface;
using ProductCatalog.DataAccess.Data.Models;
using ProductCatalog.DataAccess.Interface;
using ProductCatalog.DataAccess.Repositories;

namespace ProductCatalog.BussinessLogic.Service
{
    public class ProductService : IProductService
    {
       private readonly IProductRepository _productRepository;
       public ProductService (IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }
        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }
        public void RemoveProduct(Product product)
        {
            _productRepository.RemoveProduct(product);  
        }
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
        public Product? GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }
    }
}
