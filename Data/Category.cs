using KaravanCoffeeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KaravanCoffeeWebAPI.Data
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        /*[NotMapped]
        public IFormFile Image { get; set; }*/

        [HiddenInput(DisplayValue = false)]
        public string ImagePath { get; set; }

        public virtual IList<Product> products { get; set; }
        public virtual IList<SubCategory> subCategories { get; set; }
    }
}
