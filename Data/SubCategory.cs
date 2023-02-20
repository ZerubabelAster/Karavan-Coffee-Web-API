using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaravanCoffeeWebAPI.Data
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryDescription { get; set; }

        /*[NotMapped]
        public IFormFile Image { get; set; }*/

        [HiddenInput(DisplayValue = false)]
        public string ImagePath { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        //public Category Category { get; set; }

        public virtual IList<Product> products { get; set; }
    }
}
