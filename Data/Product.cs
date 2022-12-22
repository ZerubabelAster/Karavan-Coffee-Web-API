namespace KaravanCoffeeWebAPI.Data
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public string ProductSubCategory { get; set; }
        public string ImagePath { get; set; }
        public double UnitPrice { get; set; }
        public List<string> Ingredients { get; set; } // list of ingredients
        public List<int> Extras { get; set; }  // list of productId of extra products
        public bool Orderable { get; set; } // True if product is orderable
        public bool Active { get; set; }
        public double Discount { get; set; }
        public int ProductPoint { get; set; }
        public double Rating { get; set; }
        public int TotalOrdered { get; set; }
        public DateTime EPT { get; set; } //Estimated Preparation Time for the Product
    }
}
