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
                    ProductId = 1,
                    ProductCode = "PML-000001",
                    ProductName = "ANBESA BEER",
                    ProductDescription = "",
                    CategoryId = 1,
                    SubCategoryId = 1,
                    ImagePath = "",
                    UnitPrice = 35.00,
                    MainIngredients = "",
                    Active = false,
                    RequireExtra = false,
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 2,
                    ProductCode = "PML-000002",
                    ProductName = "ARADA BEER",
                    ProductDescription = "",
                    CategoryId = 1,
                    SubCategoryId = 1,
                    ImagePath = "",
                    UnitPrice = 45.00,
                    MainIngredients = "",
                    Active = false,
                    RequireExtra = false,
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, new Product
                {
                    ProductId = 3,
                    ProductCode = "PML-000003",
                    ProductName = "BEDELE BEER BIG",
                    ProductDescription = "",
                    CategoryId = 1,
                    SubCategoryId = 1,
                    ImagePath = "",
                    UnitPrice = 45.00,
                    MainIngredients = "",
                    Active = false,
                    RequireExtra = false,
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, new Product
                {
                    ProductId = 4,
                    ProductCode = "PML-000004",
                    ProductName = "BEDELE BEER SMALL",
                    ProductDescription = "",
                    CategoryId = 1,
                    SubCategoryId = 1,
                    ImagePath = "",
                    UnitPrice = 43.00,
                    MainIngredients = "",
                    Active = false,
                    RequireExtra = false,
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, new Product
                {
                    ProductId = 5,
                    ProductCode = "PML-000005",
                    ProductName = "CASTLE BEER",
                    ProductDescription = "",
                    CategoryId = 1,
                    SubCategoryId = 1,
                    ImagePath = "",
                    UnitPrice = 43.00,
                    MainIngredients = "",
                    Active = false,
                    RequireExtra = false,
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, new Product
                {
                    ProductId = 6,
                    ProductCode = "PML-000006",
                    ProductName = "DASHEN BEER",
                    ProductDescription = "",
                    CategoryId = 1,
                    SubCategoryId = 1,
                    ImagePath = "",
                    UnitPrice = 43.00,
                    MainIngredients = "",
                    Active = false,
                    RequireExtra = false,
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, new Product
                {
                    ProductId = 7,
                    ProductCode = "PML-000007",
                    ProductName = "HABESHA BEER",
                    ProductDescription = "",
                    CategoryId = 1,
                    SubCategoryId = 1,
                    ImagePath = "",
                    UnitPrice = 43.00,
                    MainIngredients = "",
                    Active = false,
                    RequireExtra = false,
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, new Product
                {
                    ProductId = 8,
                    ProductCode = "PML-000008",
                    ProductName = "HARAR BEER",
                    ProductDescription = "",
                    CategoryId = 1,
                    SubCategoryId = 1, 
                    ImagePath = "",
                    UnitPrice = 43.00,
                    MainIngredients = "",
                    Active = false,
                    RequireExtra = false,
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, new Product
                {
                    ProductId = 9,
                    ProductCode = "PML-000009",
                    ProductName = "HEINEKEN BEER",
                    ProductDescription = "",
                    CategoryId = 1,
                    SubCategoryId = 1, 
                    ImagePath = "",
                    UnitPrice = 33.00,
                    MainIngredients = "",
                    Active = false,
                    RequireExtra = false,
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, new Product
                {
                    ProductId = 10,
                    ProductCode = "PML-000010",
                    ProductName = "MALTA",
                    ProductDescription = "",
                    CategoryId = 1,
                    SubCategoryId = 1, 
                    ImagePath = "",
                    UnitPrice = 43.00,
                    MainIngredients = "",
                    Active = false,
                    RequireExtra = false,
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, new Product
                {
                    ProductId = 11,
                    ProductCode = "PML-000011",
                    ProductName = "SENQ BEER",
                    ProductDescription = "",
                    CategoryId = 1,
                    SubCategoryId = 1, 
                    ImagePath = "",
                    UnitPrice = 43.00,
                    MainIngredients = "",
                    Active = false,
                    RequireExtra = false,
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, new Product
                {
                    ProductId = 12,
                    ProductCode = "PML-000012",
                    ProductName = "ST GEORGE BEER",
                    ProductDescription = "",
                    CategoryId = 1,
                    SubCategoryId = 1, 
                    ImagePath = "",
                    UnitPrice = 43.00,
                    MainIngredients = "",
                    Active = false,
                    RequireExtra = false,
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, new Product
                {
                    ProductId = 13,
                    ProductCode = "PML-000013",
                    ProductName = "WALIA BEER",
                    ProductDescription = "",
                    CategoryId = 2,
                    SubCategoryId = 1, 
                    ImagePath = "",
                    UnitPrice = 43.00,
                    MainIngredients = "",
                    Active = false,
                    RequireExtra = false,
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }
                );
        }
    }
}