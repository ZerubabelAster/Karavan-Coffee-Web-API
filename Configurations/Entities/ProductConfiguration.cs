﻿using KaravanCoffeeWebAPI.Data;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Ocsp;
using System;
using System.IO.Pipelines;
using System.Net;
using System.Text.RegularExpressions;

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
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED BEER",
                    ImagePath = "",
                    UnitPrice = 35.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
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
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED BEER",
                    ImagePath = "",
                    UnitPrice = 45.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, 
                new Product
                {
                    ProductId = 3,
                    ProductCode = "PML-000003",
                    ProductName = "BEDELE BEER BIG",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED BEER",
                    ImagePath = "",
                    UnitPrice = 45.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, 
                new Product
                {
                    ProductId = 4,
                    ProductCode = "PML-000004",
                    ProductName = "BEDELE BEER SMALL",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED BEER",
                    ImagePath = "",
                    UnitPrice = 43.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, 
                new Product
                {
                    ProductId = 5,
                    ProductCode = "PML-000005",
                    ProductName = "CASTLE BEER",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED BEER",
                    ImagePath = "",
                    UnitPrice = 43.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, 
                new Product
                {
                    ProductId = 6,
                    ProductCode = "PML-000006",
                    ProductName = "DASHEN BEER",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED BEER",
                    ImagePath = "",
                    UnitPrice = 43.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, 
                new Product
                {
                    ProductId = 7,
                    ProductCode = "PML-000007",
                    ProductName = "HABESHA BEER",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED BEER",
                    ImagePath = "",
                    UnitPrice = 43.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, 
                new Product
                {
                    ProductId = 8,
                    ProductCode = "PML-000008",
                    ProductName = "HARAR BEER",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED BEER",
                    ImagePath = "",
                    UnitPrice = 43.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, 
                new Product
                {
                    ProductId = 9,
                    ProductCode = "PML-000009",
                    ProductName = "HEINEKEN BEER",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED BEER",
                    ImagePath = "",
                    UnitPrice = 33.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, 
                new Product
                {
                    ProductId = 10,
                    ProductCode = "PML-000010",
                    ProductName = "MALTA",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED BEER",
                    ImagePath = "",
                    UnitPrice = 43.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, 
                new Product
                {
                    ProductId = 11,
                    ProductCode = "PML-000011",
                    ProductName = "SENQ BEER",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED BEER",
                    ImagePath = "",
                    UnitPrice = 43.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, 
                new Product
                {
                    ProductId = 12,
                    ProductCode = "PML-000012",
                    ProductName = "ST GEORGE BEER",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED BEER",
                    ImagePath = "",
                    UnitPrice = 43.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, 
                new Product
                {
                    ProductId = 13,
                    ProductCode = "PML-000013",
                    ProductName = "WALIA BEER",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED BEER",
                    ImagePath = "",
                    UnitPrice = 43.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 14,
                    ProductCode = "PML-000014",
                    ProductName = "ACACIA DRY RED WINE",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED WINE",
                    ImagePath = "",
                    UnitPrice = 480.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 15,
                    ProductCode = "PML-000015",
                    ProductName = "ACACIA DRY WHITE WINE",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED WINE",
                    ImagePath = "",
                    UnitPrice = 480.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 16,
                    ProductCode = "PML-000016",
                    ProductName = "ACACIA ROSE WINE",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED WINE",
                    ImagePath = "",
                    UnitPrice = 480.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 17,
                    ProductCode = "PML-000017",
                    ProductName = "ACACIA SWEET RED WINE",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED WINE",
                    ImagePath = "",
                    UnitPrice = 480.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 18,
                    ProductCode = "PML-000018",
                    ProductName = "ACACIA SWEET WHITE WINE",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED WINE",
                    ImagePath = "",
                    UnitPrice = 480.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 19,
                    ProductCode = "PML-000019",
                    ProductName = "AWASH TEKESHINO",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED WINE",
                    ImagePath = "",
                    UnitPrice = 350.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 20,
                    ProductCode = "PML-000020",
                    ProductName = "AWASH WINE",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED WINE",
                    ImagePath = "",
                    UnitPrice = 250.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 21,
                    ProductCode = "PML-000021",
                    ProductName = "AXUMIT RED WINE",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED WINE",
                    ImagePath = "",
                    UnitPrice = 350.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 22,
                    ProductCode = "PML-000022",
                    ProductName = "HENDEKE RED WINE",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED WINE",
                    ImagePath = "",
                    UnitPrice = 250.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 23,
                    ProductCode = "PML-000023",
                    ProductName = "RIFT VALLEY MERLOT",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED WINE",
                    ImagePath = "",
                    UnitPrice = 480.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 24,
                    ProductCode = "PML-000024",
                    ProductName = "RIFT VALLEY CHARDONNAY",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED WINE",
                    ImagePath = "",
                    UnitPrice = 480.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 25,
                    ProductCode = "PML-000025",
                    ProductName = "SHEBELE WHITE WINE",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED WINE",
                    ImagePath = "",
                    UnitPrice = 250.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 26,
                    ProductCode = "PML-000026",
                    ProductName = "TEJ 1 LITER",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "BOTTLED WINE",
                    ImagePath = "",
                    UnitPrice = 280.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 27,
                    ProductCode = "PML-000027",
                    ProductName = "ST.GEORGE JAMBO DRAFT",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "DRAFT BEER",
                    ImagePath = "",
                    UnitPrice = 34.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 28,
                    ProductCode = "PML-000028",
                    ProductName = "ST.GEORGE SINGLE DRAFT",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "DRAFT BEER",
                    ImagePath = "",
                    UnitPrice = 23.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 29,
                    ProductCode = "PML-000029",
                    ProductName = "WALIA JAMBO DRAFT",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "DRAFT BEER",
                    ImagePath = "",
                    UnitPrice = 34.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 30,
                    ProductCode = "PML-000030",
                    ProductName = "WALIA SINGLE DRAFT",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "DRAFT BEER",
                    ImagePath = "",
                    UnitPrice = 23.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 31,
                    ProductCode = "PML-000031",
                    ProductName = "ABSOLUTE VODKA HALF BOTTLE(MEZO)",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "LIQUOR",
                    ImagePath = "",
                    UnitPrice = 1200.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 32,
                    ProductCode = "PML-000032",
                    ProductName = "BLACK LABEL DOUBLE SHOT",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "LIQUOR",
                    ImagePath = "",
                    UnitPrice = 280.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 33,
                    ProductCode = "PML-000033",
                    ProductName = "CHIVAS REGAL DOUBLE SHOT",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "LIQUOR",
                    ImagePath = "",
                    UnitPrice = 150.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 34,
                    ProductCode = "PML-000034",
                    ProductName = "JACK  DANIELS HALF BOTTLE(MEZO)",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "LIQUOR",
                    ImagePath = "",
                    UnitPrice = 4800.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 35,
                    ProductCode = "PML-000035",
                    ProductName = "OX CAFE",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "LIQUOR",
                    ImagePath = "",
                    UnitPrice = 4200.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 36,
                    ProductCode = "PML-000036",
                    ProductName = "RED LABEL DOUBLE SHAT",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "LIQUOR",
                    ImagePath = "",
                    UnitPrice = 150.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 37,
                    ProductCode = "PML-000037",
                    ProductName = "SPECIAL GOLD LABEL WHISKY",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "LIQUOR",
                    ImagePath = "",
                    UnitPrice = 5000.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 38,
                    ProductCode = "PML-000038",
                    ProductName = "STOLICHINYA DOUBLE SHAT",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "LIQUOR",
                    ImagePath = "",
                    UnitPrice = 165.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 39,
                    ProductCode = "PML-000039",
                    ProductName = "WHITE HORSE DOUBLE SHAT",
                    ProductDescription = "",
                    ProductCategory = "ALCOHOLIC BEVERAGES",
                    ProductSubCategory = "LIQUOR",
                    ImagePath = "",
                    UnitPrice = 75.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 40,
                    ProductCode = "PML-000040",
                    ProductName = "CHOCOLATE CHIP BISCUIT",
                    ProductDescription = "",
                    ProductCategory = "BAKERY",
                    ProductSubCategory = "BISCUITS",
                    ImagePath = "",
                    UnitPrice = 75.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 41,
                    ProductCode = "PML-000041",
                    ProductName = "OATS BISCUTE",
                    ProductDescription = "",
                    ProductCategory = "BAKERY",
                    ProductSubCategory = "BISCUITS",
                    ImagePath = "",
                    UnitPrice = 80.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 42,
                    ProductCode = "PML-000042",
                    ProductName = "VANILLA BISCUIT",
                    ProductDescription = "",
                    ProductCategory = "BAKERY",
                    ProductSubCategory = "BISCUITS",
                    ImagePath = "",
                    UnitPrice = 60.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 43,
                    ProductCode = "PML-000043",
                    ProductName = "200GM BREAD",
                    ProductDescription = "",
                    ProductCategory = "BAKERY",
                    ProductSubCategory = "BREAD",
                    ImagePath = "",
                    UnitPrice = 8.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 44,
                    ProductCode = "PML-000044",
                    ProductName = "2KG HABESHA BREAD",
                    ProductDescription = "",
                    ProductCategory = "BAKERY",
                    ProductSubCategory = "BREAD",
                    ImagePath = "",
                    UnitPrice = 175.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 45,
                    ProductCode = "PML-000045",
                    ProductName = "300GM BERAD",
                    ProductDescription = "",
                    ProductCategory = "BAKERY",
                    ProductSubCategory = "BREAD",
                    ImagePath = "",
                    UnitPrice = 15.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 46,
                    ProductCode = "PML-000046",
                    ProductName = "4KG HABESHA BREAD",
                    ProductDescription = "",
                    ProductCategory = "BAKERY",
                    ProductSubCategory = "BREAD",
                    ImagePath = "",
                    UnitPrice = 350.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 47,
                    ProductCode = "PML-000047",
                    ProductName = "500GM BERAD",
                    ProductDescription = "",
                    ProductCategory = "BAKERY",
                    ProductSubCategory = "BREAD",
                    ImagePath = "",
                    UnitPrice = 20.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 48,
                    ProductCode = "PML-000048",
                    ProductName = "NORMAL BREAD",
                    ProductDescription = "",
                    ProductCategory = "BAKERY",
                    ProductSubCategory = "BREAD",
                    ImagePath = "",
                    UnitPrice = 5.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }, 
                new Product
                {
                    ProductId = 49,
                    ProductCode = "PML-000049",
                    ProductName = "SLICE BREAD",
                    ProductDescription = "",
                    ProductCategory = "BAKERY",
                    ProductSubCategory = "BREAD",
                    ImagePath = "",
                    UnitPrice = 30.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 50,
                    ProductCode = "PML-000050",
                    ProductName = "1KG COOKIES",
                    ProductDescription = "",
                    ProductCategory = "BAKERY",
                    ProductSubCategory = "COOKIES",
                    ImagePath = "",
                    UnitPrice = 400.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 51,
                    ProductCode = "PML-000051",
                    ProductName = "1/2KG COOKIES",
                    ProductDescription = "",
                    ProductCategory = "BAKERY",
                    ProductSubCategory = "COOKIES",
                    ImagePath = "",
                    UnitPrice = 200.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 52,
                    ProductCode = "PML-000052",
                    ProductName = "1/2KG PANETTONE",
                    ProductDescription = "",
                    ProductCategory = "BAKERY",
                    ProductSubCategory = "PANETTONE",
                    ImagePath = "",
                    UnitPrice = 200.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 53,
                    ProductCode = "PML-000053",
                    ProductName = "APPLE PIE",
                    ProductDescription = "",
                    ProductCategory = "BAKERY",
                    ProductSubCategory = "TARTS",
                    ImagePath = "",
                    UnitPrice = 95.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                },
                new Product
                {
                    ProductId = 54,
                    ProductCode = "PML-000054",
                    ProductName = "CHOCOLATE TART",
                    ProductDescription = "",
                    ProductCategory = "BAKERY",
                    ProductSubCategory = "TARTS",
                    ImagePath = "",
                    UnitPrice = 85.00,
                    Ingredients = "",
                    Active = false,
                    Orderable = false,
                    Extras = "",
                    Discount = 0.00,
                    ProductPoint = 0,
                    Rating = 5,
                    TotalOrdered = 0
                }

                );
        }
    }
}