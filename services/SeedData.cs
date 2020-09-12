using Microsoft.EntityFrameworkCore;
using webapi_tokenauth.Models;

namespace webapi_tokenauth.services
{
    public static class SeedData
    {
        public static void SeedCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new Category { Id = 1, ParentId = 0, HaveChild = true, Title = "cat-1", Img = "" },
                new Category { Id = 2, ParentId = 1, HaveChild = false, Title = "cat-2", Img = "" },
                new Category { Id = 3, ParentId = 1, HaveChild = false, Title = "cat-3", Img = "" },
                new Category { Id = 4, ParentId = 1, HaveChild = false, Title = "cat-4", Img = "" },
                new Category { Id = 5, ParentId = 1, HaveChild = false, Title = "cat-5", Img = "" }
                //  Category =new Category { Id = 3, ParentId = 0, HaveChild = true, Title = "", Img = ""  },
                );
        }

        public static void SeedProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "product-1", Description = "", Img = "", Category = new Category { Id = 1 } },
                new Product { Id = 2, Title = "product-2", Description = "", Img = "", Category = new Category { Id = 1 } },
                new Product { Id = 3, Title = "product-3", Description = "", Img = "", Category = new Category { Id = 1 } },
                new Product { Id = 4, Title = "product-4", Description = "", Img = "", Category = new Category { Id = 1 } },
                new Product { Id = 5, Title = "product-5", Description = "", Img = "", Category = new Category { Id = 2 } },
                new Product { Id = 6, Title = "product-6", Description = "", Img = "", Category = new Category { Id = 2 } },
                new Product { Id = 7, Title = "product-7", Description = "", Img = "", Category = new Category { Id = 3 } },
                new Product { Id = 8, Title = "product-8", Description = "", Img = "", Category = new Category { Id = 3 } },
                new Product { Id = 9, Title = "product-9", Description = "", Img = "", Category = new Category { Id = 4 } },
                new Product { Id = 10, Title = "product-10", Description = "", Img = "", Category = new Category { Id = 5 } },
                new Product { Id = 11, Title = "product-11", Description = "", Img = "", Category = new Category { Id = 1 } },
                new Product { Id = 11, Title = "product-12", Description = "", Img = "", Category = new Category { Id = 5 } },
                new Product { Id = 13, Title = "product-13", Description = "", Img = "", Category = new Category { Id = 1 } },
                new Product { Id = 14, Title = "product-14", Description = "", Img = "", Category = new Category { Id = 3 } },
                new Product { Id = 15, Title = "product-15", Description = "", Img = "", Category = new Category { Id = 1 } }
            );
        }
    }
}
