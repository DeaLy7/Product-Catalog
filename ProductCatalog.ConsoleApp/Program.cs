using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.BussinessLogic.Interface;
using ProductCatalog.BussinessLogic.Service;
using ProductCatalog.ConsoleApp.Controllers;
using ProductCatalog.DataAccess.Data;
using ProductCatalog.DataAccess.Data.Models;
using ProductCatalog.DataAccess.Interface;
using ProductCatalog.DataAccess.Repositories;

namespace ProductCatalog.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ProductDbContext>();
            dbContextOptionsBuilder.UseSqlite(connectionString);
            var dbContext = new ProductDbContext(dbContextOptionsBuilder.Options);
            var productRepository = new ProductRepository(dbContext);
            var productService = new ProductService(productRepository);

            IServiceProvider GetServiceProvider()
            {
                IServiceCollection services = new ServiceCollection()
                    .AddTransient<IProductRepository, ProductRepository>()
                    .AddTransient<IProductService, ProductService>()
                    .AddTransient<ProductController>()
                    .AddDbContext<ProductDbContext>(options => options.UseSqlite(connectionString));
                return services.BuildServiceProvider();
            }

            var serviceProvider = GetServiceProvider();
            var productController = serviceProvider.GetRequiredService<ProductController>();
            bool Exit = false;
            Product product;
            while (!Exit)
            {
                Console.WriteLine("# # # # # Products App # # # # #");
                Console.WriteLine("1 - View Products | 2 - Create Product | 3 - Update Product | 4 - Delete Product | 0 - Exit");
                int number = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (number)
                {
                    case 1:
                        Console.WriteLine("# # # # # Products App # # # # # ");
                        Console.WriteLine("Your Products:\r\n- - - - - - - - - - - -");
                        var productList = productController.GetAllProducts();
                        if (productList == null || productList.Count == 0)
                        {
                            Console.WriteLine("Not found Product");

                        } 
                        else
                        {
                            Console.WriteLine("Not found Product");
                            foreach (var p in productList.ToList())
                            {
                                Console.WriteLine($"Id: {p.Id} \r\nTitle: {p.Name}\r\nDescription: {p.Description}\r\nPrice: {p.Price} грн\r\n - - - - - - - - - - - -");
                            }
                        }
                        
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("# # # # # Products App # # # # # \r\nCreating new product:");
                        product = new Product();
                        Console.Write("Name: ");
                        product.Name = Console.ReadLine();
                        Console.Write("Content: ");
                        product.Description = Console.ReadLine();
                        Console.Write("Price: ");
                        product.Price = Convert.ToInt32(Console.ReadLine());
                        productController.AddProduct(product);
                        Console.Write("Success\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("# # # # # Products App # # # # # \r\nUpdating product:");


                        if (productController.GetProductById != null)
                        {
                            Console.WriteLine("У вас нет записей, чтобы их редактировать");
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        }
                        else
                        {
                            foreach (var p in productController.GetAllProducts().ToList())
                            {
                                Console.WriteLine($"Id: {p.Id} \r\nTitle: {p.Name}\r\nDescription: {p.Description}\r\nPrice: {p.Price} грн\r\n - - - - - - - - - - - -");
                            }
                        }
                        Console.Write("Напишите Id заметки, чтобы её изменить: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        var productFind = productController.GetProductById(id);
                        if (productFind != null)
                        {
                            productFind.Name = Console.ReadLine();
                            productFind.Description = Console.ReadLine();
                            productFind.Price = Convert.ToInt32(Console.ReadLine());
                            productController.UpdateProduct(productFind);

                        }
                        Console.Write("Success\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("# # # # # Products App # # # # # \r\nDeleting product:");
                        productController.GetAllProducts();
                        if (productController.GetProductById == null)
                        {
                            Console.WriteLine("У вас нет записей для удаления");
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        }
                        else
                        {
                            foreach (var p in productController.GetAllProducts().ToList())
                            {
                                Console.WriteLine($"Id: {p.Id} \r\nTitle: {p.Name}\r\nDescription: {p.Description}\r\nPrice: {p.Price} грн\r\n - - - - - - - - - - - -");
                                Console.WriteLine();
                            }
                        }
                        Console.Write("Напишите Id заметки, чтобы её удалить: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        productFind = productController.GetProductById(id);
                        if (productFind != null)
                        {
                            productController.RemoveProduct(productFind);

                        }
                        Console.Write("Success\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;



                    case 0:
                        Exit = true;
                        break;
                }

            }
        }
    }
}