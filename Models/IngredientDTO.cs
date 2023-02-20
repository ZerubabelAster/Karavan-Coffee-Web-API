using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace KaravanCoffeeWebAPI.Models
{
    public class CreateIngredientDTO
    {
        [Required]
        public string IngredientCode { get; set; }
        [Required]
        public string IngredientName { get; set; }

        public string IngredientDescription { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public bool Active { get; set; }
        public double Discount { get; set; }

        public IFormFile Image { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImagePath { get; set; }
    }
    public class UpdateIngredientDTO : CreateIngredientDTO
    {

    }
    public class IngredientDTO : CreateIngredientDTO
    {
        public int IngredientId { get; set; }

        public ICollection<ProductDTO> ProductsDTO { get; set; }

    }
}
