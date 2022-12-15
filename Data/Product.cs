namespace KaravanCoffeeWebAPI.Data
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double UnitPrice { get; set; }
        public string ProductCategory { get; set; }
        public string ProductSubCategory { get; set; }
        public string ImagePath { get; set; }
        public string Keyword { get; set; }
        public double Rating { get; set; }
        public byte RequireExtra { get; set; }
        public double Discount { get; set; }
        public int ProductPoint { get; set; }
        public byte Active { get; set; }
    }
}
