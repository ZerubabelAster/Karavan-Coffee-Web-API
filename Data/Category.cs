using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaravanCoffeeWebAPI.Data
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImagePath { get; set; }

        public virtual IList<Product> Products { get; set; }

    }
}
