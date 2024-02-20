using ProductCatalog.BussinessLogic.Interface;
using ProductCatalog.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.ConsoleApp.Controllers
{
    public class ProductController 
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
           _productService = productService;
        }
        public void AddProduct(Product product)
        {
            _productService.AddProduct(product);
        }
        public void UpdateProduct(Product product)
        {
            _productService.UpdateProduct(product);
        }
        public void RemoveProduct(Product product)
        {
            _productService.RemoveProduct(product);
        }
        public List<Product> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }
        public Product? GetProductById(int id)
        {
            return _productService.GetProductById(id);
        }
    }
}
