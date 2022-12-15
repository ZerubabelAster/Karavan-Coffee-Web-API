using System.ComponentModel.DataAnnotations.Schema;

namespace KaravanCoffeeWebAPI.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderType { get; set; }
        public string OrderedBy { get; set; }
        public string PaymentMode { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDateTime { get; set; }
        public DateTime PickupDateTime { get; set; }
        public double TotalPrice { get; set; }
        public int RedeemedPoints { get; set; }
        public string ApprovedBy { get; set; }
        public string DeliveredBy { get; set; }
        public byte Void { get; set; }

        [ForeignKey(nameof(Branch))]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        [ForeignKey(nameof(Person))]
        public string UserId { get; set; }
        public Person Person { get; set; }
    }
}
