using System.Collections.Generic;

namespace PomeloDbUpdateException
{
    public class Category
    {
        public Category()
        {
            ProductCategories = new List<ProductCategory>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
