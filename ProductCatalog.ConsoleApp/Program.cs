﻿using Microsoft.EntityFrameworkCore;
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
            var config = GetConfiguration();
            var connectionString = config.GetConnectionString("DefaultConnection");
            var serviceProvider = GetServiceProvider();
            var productController = serviceProvider.GetRequiredService<ProductController>();
            var categoryController = serviceProvider.GetRequiredService<CategoryController>();
            bool Exit = false;
            Product product;
            Category category;


            IConfiguration GetConfiguration()
            {
                var configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
                configurationBuilder.AddJsonFile("appsettings.json");
                return configurationBuilder.Build();
            }
            IServiceProvider GetServiceProvider()
            {
                IServiceCollection services = new ServiceCollection()
                    .AddTransient<IProductRepository, ProductRepository>()
                    .AddTransient<IProductService, ProductService>()
                    .AddTransient<ProductController>()
                    .AddTransient<ICategoryRepository, CategoryRepository>()
                    .AddTransient<ICategoryService, CategoryService>()
                    .AddTransient<CategoryController>()
                    .AddDbContext<ProductDbContext>(options => options.UseSqlite(connectionString));
                return services.BuildServiceProvider();
            }

            while (!Exit)
            {
                Console.WriteLine("# # # # # Console App # # # # #");
                Console.WriteLine("1 -  Products | 2 - Category | 3 - Exit");
                int menu = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (menu == 1)
                {
                    
                    bool leaveFromProductMenu = false;
                    while (!leaveFromProductMenu)
                    {
                        Console.WriteLine("# # # # # Products App # # # # #");
                        Console.WriteLine("1 - View Products | 2 - Create Product | 3 - Update Product | 4 - Delete Product | 0 - Exit");
                        menu = Convert.ToInt32(Console.ReadLine()); 
                        Console.Clear();
                        switch (menu)
                        {
                            case 1:

                                
                                
                                    Console.WriteLine("# # # # # Products App # # # # # ");
                                    Console.WriteLine("Your Products:\r\n- - - - - - - - - - - -");
                                    var productList = productController.GetAllProducts();
                                    if (productList == null || productList.Count == 0)
                                    {
                                        Console.WriteLine("Not found Product");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    }
                                    foreach (var p in productList.ToList())
                                    {
                                        Console.WriteLine($"Id: {p.Id} \r\nTitle: {p.Name}\r\nDescription: {p.Description}\r\nPrice: {p.Price} грн\r\n - - - - - - - - - - - -");
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
                                    foreach (var p in productController.GetAllProducts().ToList())
                                    {
                                        Console.WriteLine($"Id: {p.Id} \r\nTitle: {p.Name}\r\nDescription: {p.Description}\r\nPrice: {p.Price} грн\r\n - - - - - - - - - - - -");
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
                                    foreach (var p in productController.GetAllProducts().ToList())
                                    {
                                        Console.WriteLine($"Id: {p.Id} \r\nTitle: {p.Name}\r\nDescription: {p.Description}\r\nPrice: {p.Price} грн\r\n - - - - - - - - - - - -");
                                        Console.WriteLine();
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
                                
                                    leaveFromProductMenu = true;
                                    break;
                                
                                
                        }
                    } 

                }
                if (menu == 2)
                {
                    bool leaveFromCategoryMenu = false;
                    while (!leaveFromCategoryMenu)
                    {
                        Console.WriteLine("# # # # # Categories App # # # # #");
                        Console.WriteLine("1 - View Categories | 2 - Create Category | 3 - Update Category | 4 - Delete Category | 0 - Exit");      
                        menu = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        switch (menu)
                        {
                            case 1:

                                Console.WriteLine("# # # # # Categories App # # # # # ");
                                Console.WriteLine("Your categories:\r\n- - - - - - - - - - - -");
                                var categoryList = categoryController.GetAllCategories();
                               
                                if (categoryList == null || !categoryList.Any())
                                {
                                    Console.WriteLine("Not found Category");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                }
                                
                                foreach (var p in categoryList.ToList())
                                {                                  
                                    Console.WriteLine($"Id: {p.Id} \r\nName: {p.Name}");
                                    if (p.ParentCategory != null)
                                    {
                                        Console.WriteLine($"ParentCategory: {p.ParentCategory.Name}\r\n- - - - - - - - - - - -");
                                    }
                                    if (p.ChildCategories != null && p.ChildCategories.Any())
                                        {
                                            Console.Write($"ChildCategories: ");
                                            foreach (var childCategory in p.ChildCategories)
                                            {
                                                Console.Write($" {childCategory.Name}");
                                            }
                                            Console.WriteLine("\r\n- - - - - - - - - - - -");
                                        }
                                     
                                }
                                
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            case 2:

                                Console.WriteLine("# # # # # Category App # # # # # \r\nCreating new category:");
                                Console.WriteLine("1 - Создать категорию | 2 - Создать подкатегорию");
                                int categorySelect = Convert.ToInt32(Console.ReadLine());
                                if (categorySelect == 1)
                                {
                                    category = new Category();
                                    Console.Write("Name: ");
                                    category.Name = Console.ReadLine();
                                    categoryController.AddCategory(category);
                                    Console.Write("Success\n");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                if (categorySelect == 2)
                                {
                                    var categoryListForCreate = categoryController.GetAllCategories();
                                    foreach (var p in categoryListForCreate.ToList())
                                    {
                                        if (p.ParentCategory == null)
                                        {
                                           Console.WriteLine($"Id: {p.Id} \r\nName: {p.Name}");
                                        }   
                                    }
                                    
                                    Console.Write("Введите id категории для создания подкатегории: ");
                                    int categoriID = Convert.ToInt32(Console.ReadLine());
                                    category = new Category();
                                    Console.Write("Name: ");
                                    category.Name = Console.ReadLine();                                   
                                    category.ParentCategoryId = categoriID;
                                    categoryController.AddCategory(category);
                                    Console.Clear();
                                }
                                break;
                            case 3:
                                Console.WriteLine("# # # # # Category App # # # # # \r\nUpdating category:");                                
                                Console.WriteLine("1 - Обновить категорию | 2 - Обновить подкатегорию");
                                categorySelect = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                if (categorySelect == 1)
                                {
                                    Console.WriteLine("# # # # # List Categories # # # # # ");
                                    foreach (var p in categoryController.GetAllCategories().ToList())
                                    {                                        
                                            
                                            if (p.ParentCategory == null)
                                            {
                                                Console.WriteLine($"Id: {p.Id} \r\nName: {p.Name}");
                                            }                                            
                                                   
                                    }
                                    Console.Write("Напишите Id заметки, чтобы её изменить: ");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    var categoryFind = categoryController.GetCategoryById(id);
                                    Console.Clear();
                                    if (categoryFind != null)
                                    {
                                        Console.Write("Name: ");
                                        categoryFind.Name = Console.ReadLine();  
                                        categoryController.UpdateCategory(categoryFind);
                                        Console.Write("Success\n");

                                    }
                                    else
                                    {
                                        Console.WriteLine("Введен некорректный ID");
                                    }
                                    
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                if (categorySelect == 2)
                                {
                                    var categoryListForCreate = categoryController.GetAllCategories();
                                    foreach (var p in categoryListForCreate.ToList())
                                    {
                                        if (p.ChildCategories == null)
                                        {
                                            Console.WriteLine($"Id: {p.Id} \r\nName: {p.Name}");
                                        }
                                    }
                                    Console.Write("Введите id категории для изменение подкатегории: ");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    var categoryFind = categoryController.GetCategoryById(id);
                                    Console.Clear();
                                    if (categoryFind != null)
                                    {
                                        Console.Write("Name: ");
                                        categoryFind.Name = Console.ReadLine();
                                        categoryController.UpdateCategory(categoryFind);
                                        Console.Write("Success\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Введен некорректный ID");
                                    }
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                break;
                            case 4:
                                Console.WriteLine("# # # # # Category App # # # # # \r\nDeleting category:");                               
                                Console.WriteLine("1 - Удалить категорию | 2 - Удалить подкатегорию");
                                categorySelect = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();
                                if (categorySelect == 1)
                                {
                                    Console.WriteLine("# # # # # List Categories # # # # # ");
                                    foreach (var p in categoryController.GetAllCategories().ToList())
                                    {
                                        if (p.ParentCategory == null)
                                        {
                                            Console.WriteLine($"Id: {p.Id} \r\nName: {p.Name}");
                                        }
                                    }
                                    Console.Write("Введите Id категории: ");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    var categoryFind = categoryController.GetCategoryById(id);
                                    Console.Clear();
                                    if (categoryFind != null)
                                    {                                        
                                        categoryController.RemoveCategory(categoryFind);
                                        Console.Write("Success\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Введен некорректный ID");
                                    }
                                    
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                if (categorySelect == 2)
                                {
                                    var categoryListForDelete = categoryController.GetAllCategories();
                                    foreach (var p in categoryListForDelete.ToList())
                                    {
                                        if (p.ChildCategories == null)
                                        {
                                            Console.WriteLine($"Id: {p.Id} \r\nName: {p.Name}");
                                        }
                                    }
                                    Console.Write("Введите id для удаление подкатегории: ");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    var categoryFind = categoryController.GetCategoryById(id);
                                    Console.Clear();
                                    if (categoryFind != null)
                                    {
                                        categoryController.RemoveCategory(categoryFind);
                                        Console.Write("Success\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Вы ввели некорректный ID");
                                    }
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                break;
                            case 0:
                                leaveFromCategoryMenu = true;
                                break;

                               
                                
                        }
                    }
                }
            }
        }
    }
}