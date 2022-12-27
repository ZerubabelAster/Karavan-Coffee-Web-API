using KaravanCoffeeWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KaravanCoffeeWebAPI.Configurations.Entities
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasData(
                new SubCategory
                {
                    SubCategoryId = 1,
                    SubCategoryName = "ALCOHOLIC BEVERAGES",
                    SubCategoryDescription = "",
                    ImagePath = "",
                    CategoryId= 1,
                },
                new SubCategory
                {
                    SubCategoryId = 2,
                    SubCategoryName = "Cake",
                    SubCategoryDescription = "",
                    ImagePath = "",
                    CategoryId = 1,
                },
                new SubCategory
                {
                    SubCategoryId = 3,
                    SubCategoryName = "Bakery",
                    SubCategoryDescription = "",
                    ImagePath = "",
                    CategoryId = 1,
                },
                new SubCategory
                {
                    SubCategoryId = 4,
                    SubCategoryName = "Ice Cream",
                    SubCategoryDescription = "",
                    ImagePath = "",
                    CategoryId = 1,
                },
                new SubCategory
                {
                    SubCategoryId = 5,
                    SubCategoryName = "Habeshan Dish",
                    SubCategoryDescription = "",
                    ImagePath = "",
                    CategoryId = 1,
                }
                );
        } 
    }
}
