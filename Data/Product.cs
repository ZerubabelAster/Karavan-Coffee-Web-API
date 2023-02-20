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
        public double UnitPrice { get; set; }
        public bool Active { get; set; }
        public double Discount { get; set; }
        public int ProductPoint { get; set; }
        public double Rating { get; set; }
        public int AverageQueueDay { get; set; }
        public TimeOnly AverageQueueTime { get; set; }
        public bool Orderable { get; set; }
        public string Tag { get; set; }
        /*        [NotMapped]
                public IFormFile Image { get; set; }*/

        [HiddenInput(DisplayValue = false)]
        public string ImagePath { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey(nameof(SubCategory))]
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        //public virtual ICollection<Ingredient> Ingredients { get; set; }

    }
}
