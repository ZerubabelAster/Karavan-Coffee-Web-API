using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KaravanCoffeeWebAPI.Models
{
    public class CreateProductDTO
    {
        private const string time = ("00:00:00");

        [Required]
        public string ProductCode { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        public string MainIngredients { get; set; } // Before: Keywords, comma separated

        [Required]
        public bool Active { get; set; }


        [DefaultValue(0)]
        public double Discount { get; set; }
        public int ProductPoint { get; set; }

        [Range(1, 5)]
        public double Rating { get; set; }

        [DefaultValue(0)]
        public int AverageQueueDay { get; set; }
        [DefaultValue(time)]
        public TimeOnly AverageQueueTime { get; set; }
        [DefaultValue(false)]
        public bool Orderable { get; set; }
        public string Tag { get; set; }
        //[RequestSizeLimit(10485760)] /*, ErrorMessage = "File Size Must be"*/
        public IFormFile Image { get; set; }

        [HiddenInput(DisplayValue = false)]
        [StringLength(int.MaxValue)]
        public string ImagePath { get; set; }

        public int CategoryId { get; set; }

        public int SubCategoryId { get; set; }
    }
    public class UpdateProductDTO : CreateProductDTO
    {

    }
    public class ProductDTO : CreateProductDTO
    {
        public int ProductId { get; set; }

        public ICollection<IngredientDTO> IngredientsDTO { get; set; }
    }
}
