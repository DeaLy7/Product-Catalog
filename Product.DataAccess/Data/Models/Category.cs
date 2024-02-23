namespace ProductCatalog.DataAccess.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }      
        public Category? ParentCategory;
        public int? ParentCategoryId;
        public List<Category>? ChildCategories;
        public List<Product>? Products { get; set; }
       
    }
}
