using System.ComponentModel.DataAnnotations.Schema;

namespace KaravanCoffeeWebAPI.Data
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public string ExtrasRequested { get; set; }
        public string RemovalRequested { get; set; }
        public double UnitPrice { get; set; }
        public double ExtraCharge { get; set; }
        public double Discount { get; set; }
        public double SubTotal { get; set; } // VAT and GrandTotal calculated based on SubTotal, which are both not needed to be stored
        public double Rating { get; set; }

        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
