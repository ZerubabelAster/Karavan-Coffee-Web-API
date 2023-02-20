using KaravanCoffeeWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KaravanCoffeeWebAPI.Configurations.Entities
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "ALCOHOLIC BEVERAGES",
                    CategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "BAKERY",
                    CategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "CAKE",
                    CategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "COLD BEVERAGES",
                    CategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "FAST FOOD",
                    CategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "FRUIT BEVERAGES",
                    CategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                },
                new Category
                {
                    CategoryId = 7,
                    CategoryName = "HOT BEVERAGES",
                    CategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                },
                new Category
                {
                    CategoryId = 8,
                    CategoryName = "ICE CREAM",
                    CategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                },
                new Category
                {
                    CategoryId = 9,
                    CategoryName = "SALES SUPPORT",
                    CategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                }
                );
        }
    }
}
