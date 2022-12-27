using KaravanCoffeeWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaravanCoffeeWebAPI.Models
{
    public class CreateCategoryDTO
    {
        [Required]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public IFormFile Image { get; set; }

        [HiddenInput(DisplayValue = false)]
        [StringLength(int.MaxValue)]
        public string ImagePath { get; set; }
    }

    public class UpdateCategoryDTO : CreateCategoryDTO
    {

    }

    public class CategoryDTO : CreateCategoryDTO
    {
        public int CategoryId { get; set; }

        public IList<ProductDTO> Products { get; set; }
    }
}
