using System.ComponentModel.DataAnnotations;

namespace KaravanCoffeeWebAPI.Models
{
    public class CreateProductDTO
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        [Required]
        public string ProductCategory { get; set; }

        [Required]
        public string ProductSubCategory { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public string Keyword { get; set; }

        [Required]
        public double Rating { get; set; }

        public byte RequireExtra { get; set; }

        public double Discount { get; set; }

        [Required]
        public int ProductPoint { get; set; }

        [Required]
        public byte Active { get; set; }
    }
    public class UpdateProductDTO : CreateProductDTO
    {

    }
    public class ProductDTO : CreateProductDTO
    {
        public int ProductId { get; set; }
    }
}
