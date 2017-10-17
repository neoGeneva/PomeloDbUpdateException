using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace PomeloDbUpdateException
{
    class Program
    {
        static void Main(string[] args)
        {
            var contextFactory = new DesignTimeDbContextFactory();

            using (var context = contextFactory.CreateDbContext(args))
            {
                context.Database.Migrate();

                if (!context.Categories.Any())
                {
                    context.Categories.Add(new Category()
                    {
                        Name = "Category 1"
                    });

                    context.Categories.Add(new Category()
                    {
                        Name = "Category 2"
                    });

                    context.SaveChanges();
                }

                context.ProductCategory.RemoveRange(context.ProductCategory);
                context.Products.RemoveRange(context.Products);

                context.SaveChanges();

                var categoryId = context.Categories.Select(x => x.CategoryId).First();
                var products = new List<Product>();

                for (var i = 0; i < 1000; ++i)
                {
                    var product = new Product()
                    {
                        Name = $"Product {i}",
                    };

                    product.ProductCategories.Add(new ProductCategory()
                    {
                        CategoryId = categoryId
                    });

                    if (i % 2 == 1)
                    {
                        product.ParentProduct = products[i - 1];
                    }

                    products.Add(product);
                }

                context.Products.AddRange(products);

                context.SaveChanges();
            }
        }
    }
}
