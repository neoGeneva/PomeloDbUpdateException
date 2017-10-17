using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomeloDbUpdateException
{
    public class Product
    {
        public Product()
        {
            ProductCategories = new List<ProductCategory>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public int? ParentProductId { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }

        [ForeignKey(nameof(ParentProductId))]
        public Product ParentProduct { get; set; }
        [InverseProperty(nameof(ParentProduct))]
        public List<Product> ChildProducts { get; set; }
    }
}
