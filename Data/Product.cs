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
        public string ProductCategory { get; set; }
        public string ProductSubCategory { get; set; }
        public double UnitPrice { get; set; }
        public string Ingredients { get; set; } // comma separated list of ingredients
        public string Extras { get; set; }  // comma separated list of productId of extra products
        public bool Active { get; set; }
        public double Discount { get; set; }
        public int ProductPoint { get; set; }
        public double Rating { get; set; }
        public int TotalOrdered { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        [HiddenInput]
        public string? ImagePath { get; set; }


    }
}
