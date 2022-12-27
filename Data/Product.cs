using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaravanCoffeeWebAPI.Data
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double UnitPrice { get; set; }
        public string MainIngredients { get; set; } // Before: Keywords, comma separated
        public bool Active { get; set; }
        public bool RequireExtra { get; set; }
        public double Discount { get; set; }
        public int ProductPoint { get; set; }
        public double Rating { get; set; }
        public int TotalOrdered { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImagePath { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey(nameof(SubCategory))]
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        public static implicit operator string(Product v)
        {
            throw new NotImplementedException();
        }
    }
}
