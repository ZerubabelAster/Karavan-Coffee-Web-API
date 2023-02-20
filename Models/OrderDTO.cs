using System.ComponentModel.DataAnnotations;

namespace KaravanCoffeeWebAPI.Models
{
    public class CreateOrderDTO
    {
        [Required]
        public string OrderType { get; set; }

        [Required]
        public string OrderedBy { get; set; }

        [Required]
        public string PaymentMode { get; set; }

        [Required]
        public string OrderStatus { get; set; }

        [Required]
        public DateTime OrderDateTime { get; set; }

        [Required]
        public DateTime PickupDateTime { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        public int RedeemedPoints { get; set; }

        [Required]
        public string ApprovedBy { get; set; }

        [Required]
        public string DeliveredBy { get; set; }

        [Required]
        public byte Void { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int BranchId { get; set; }
    }

    public class UpdateOrderDTO : CreateOrderDTO
    {

    }

    public class OrderDTO : CreateLoyalityDetailDTO
    {
        public int OrderId { get; set; }

        public PersonDTO Person { get; set; }
        public BranchDTO Branch { get; set; }
    }
}
