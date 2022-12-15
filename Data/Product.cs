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
        public string MainIngredients { get; set; } // Before: Keywords, comma separated
        public bool Active { get; set; }
        public bool RequireExtra { get; set; }
        public double Discount { get; set; }
        public int ProductPoint { get; set; }
        public double Rating { get; set; }
        public int TotalOrdered { get; set; }
    }
}
