using Microsoft.AspNetCore.Mvc;

namespace KaravanCoffeeWebAPI.Data
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string IngredientCode { get; set; }
        public string IngredientName { get; set; }
        public string IngredientDescription { get; set; }
        public double UnitPrice { get; set; }
        public bool Active { get; set; }
        public double Discount { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImagePath { get; set; }

        //public virtual ICollection<Product> Products { get; set; }
    }
}
