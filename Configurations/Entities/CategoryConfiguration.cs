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
                    ImagePath = "",
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Cake",
                    CategoryDescription = "",
                    ImagePath = "",
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Bakery",
                    CategoryDescription = "",
                    ImagePath = "",
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Ice Cream",
                    CategoryDescription = "",
                    ImagePath = "",
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Habeshan Dish",
                    CategoryDescription = "",
                    ImagePath = "",
                }
                );
        }
    }
}
