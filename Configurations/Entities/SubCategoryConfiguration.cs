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
                    SubCategoryName = "BOTTLED BEER",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 1,
                },
                new SubCategory
                {
                    SubCategoryId = 2,
                    SubCategoryName = "BOTTLED WINE",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 1,
                },
                new SubCategory
                {
                    SubCategoryId = 3,
                    SubCategoryName = "DRAFT BEER",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 1,
                },
                new SubCategory
                {
                    SubCategoryId = 4,
                    SubCategoryName = "LIQUOR",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 1,
                },
                new SubCategory
                {
                    SubCategoryId = 5,
                    SubCategoryName = "BISCUITS",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 2,
                },
                new SubCategory
                {
                    SubCategoryId = 6,
                    SubCategoryName = "BREAD",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 2,
                },
                new SubCategory
                {
                    SubCategoryId = 7,
                    SubCategoryName = "COOKIES",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 2,
                },
                new SubCategory
                {
                    SubCategoryId = 8,
                    SubCategoryName = "PANETTONE",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 2,
                },
                new SubCategory
                {
                    SubCategoryId = 9,
                    SubCategoryName = "TARTS",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 2,
                },
                new SubCategory
                {
                    SubCategoryId = 10,
                    SubCategoryName = "CREAM CAKE",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 3,
                },
                new SubCategory
                {
                    SubCategoryId = 11,
                    SubCategoryName = "DRY CAKE",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 3,
                },
                new SubCategory
                {
                    SubCategoryId = 12,
                    SubCategoryName = "EVENT TORTA",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 3,
                },
                new SubCategory
                {
                    SubCategoryId = 13,
                    SubCategoryName = "NOVELITY TORTA",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 3,
                },
                new SubCategory
                {
                    SubCategoryId = 14,
                    SubCategoryName = "TORTA",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 3,
                },
                new SubCategory
                {
                    SubCategoryId = 15,
                    SubCategoryName = "WEDDING CAKE",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 3,
                },
                new SubCategory
                {
                    SubCategoryId = 16,
                    SubCategoryName = "MINERAL WATER",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 4,
                },
                new SubCategory
                {
                    SubCategoryId = 17,
                    SubCategoryName = "SOFT DRINK",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 4,
                },
                new SubCategory
                {
                    SubCategoryId = 18,
                    SubCategoryName = "WATER",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 4,
                },
                new SubCategory
                {
                    SubCategoryId = 19,
                    SubCategoryName = "BREAKFAST",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 5,
                },
                new SubCategory
                {
                    SubCategoryId = 20,
                    SubCategoryName = "BURGER",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 5,
                },
                new SubCategory
                {
                    SubCategoryId = 21,
                    SubCategoryName = "FISH",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 5,
                },
                new SubCategory
                {
                    SubCategoryId = 22,
                    SubCategoryName = "MINERAL WATER",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 5,
                },
                new SubCategory
                {
                    SubCategoryId = 23,
                    SubCategoryName = "HABESHA",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 5,
                },
                new SubCategory
                {
                    SubCategoryId = 24,
                    SubCategoryName = "PIZZA & PASTA",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 5,
                },
                new SubCategory
                {
                    SubCategoryId = 25,
                    SubCategoryName = "SANDWICH & WRAPS",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 5,
                },
                new SubCategory
                {
                    SubCategoryId = 26,
                    SubCategoryName = "SIDES & SNACK",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 5,
                },
                new SubCategory
                {
                    SubCategoryId = 27,
                    SubCategoryName = "JUICE",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 6,
                },
                new SubCategory
                {
                    SubCategoryId = 28,
                    SubCategoryName = "COFFEE",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 7,
                },
                new SubCategory
                {
                    SubCategoryId = 29,
                    SubCategoryName = "ICE CREAM PUNCH",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 8,
                },
                new SubCategory
                {
                    SubCategoryId = 30,
                    SubCategoryName = "ICE CREAM SCOOP",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 8,
                },
                new SubCategory
                {
                    SubCategoryId = 31,
                    SubCategoryName = "ICE CREAM TOPPING",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 8,
                },
                new SubCategory
                {
                    SubCategoryId = 32,
                    SubCategoryName = "MILK SHAKE",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 8,
                },
                new SubCategory
                {
                    SubCategoryId = 33,
                    SubCategoryName = "PACKAGING",
                    SubCategoryDescription = "",
                    ImagePath = "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg",
                    CategoryId = 9,
                }
              );
        }
    }
}
