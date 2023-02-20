using KaravanCoffeeWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaravanCoffeeWebAPI.Models
{
    public class CreateSubCategoryDTO
    {
        [Required]
        public string SubCategoryName { get; set; }

        public string SubCategoryDescription { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImagePath { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }

    public class UpdateSubCategoryDTO : CreateSubCategoryDTO
    {

    }

    public class SubCategoryDTO : CreateSubCategoryDTO
    {
        public int SubCategoryId { get; set; }
        //public Category Category { get; set; }

        public IList<ProductDTO> products { get; set; }
    }
}
