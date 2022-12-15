using System.ComponentModel.DataAnnotations;

namespace KaravanCoffeeWebAPI.Models
{
    public class CreateProductDTO
    {
        [Required]
        public string ProductCode { get; set; }

        [Required]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        [Required]
        public string ProductCategory { get; set; }

        [Required]
        public string ProductSubCategory { get; set; }
        public string ImagePath { get; set; }

        [Required]
        public double UnitPrice { get; set; }
        public string MainIngredients { get; set; } // Before: Keywords, comma separated

        [Required]
        public bool Active { get; set; }
        public bool RequireExtra { get; set; }
        public double Discount { get; set; }
        public int ProductPoint { get; set; }

        [Range(1, 5)]
        public double Rating { get; set; }
        public int TotalOrdered { get; set; }
    }
    public class UpdateProductDTO : CreateProductDTO
    {

    }
    public class ProductDTO : CreateProductDTO
    {
        public int ProductId { get; set; }
    }
}
