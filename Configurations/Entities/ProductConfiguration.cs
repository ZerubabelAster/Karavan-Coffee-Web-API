using KaravanCoffeeWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KaravanCoffeeWebAPI
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    ProductId = 2,
                    ProductName = "test",
                    ProductDescription= "test",
                    UnitPrice = 10,
                    ProductCategory= "test",
                    ProductSubCategory= "test",
                    ImagePath = "test",
                    Keyword= "test",
                    Rating= 4,
                    RequireExtra = 1,
                    Discount= 2,
                    ProductPoint = 10,
                    Active = 1
                }
                );
        }
    }
}