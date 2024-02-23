
using Microsoft.EntityFrameworkCore;
using ProductCatalog.DataAccess.Data.Models;
using System.Reflection;

namespace ProductCatalog.DataAccess.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext> options): base(options) 
        { 
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                        .HasMany(p => p.Categories)
                        .WithMany(c => c.Products)
                        .UsingEntity("ProductCategories ");
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(p => p.ChildCategories)
                .OnDelete(DeleteBehavior.SetNull)
                .HasForeignKey(s => s.ParentCategoryId);
            
              
        }
    }
}
