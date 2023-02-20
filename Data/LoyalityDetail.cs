using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaravanCoffeeWebAPI.Data
{
    public class LoyalityDetail
    {
        [Key]
        public int LoyalityId { get; set; }

        public int Quantity { get; set; }

        public int LoyalityPoint { get; set; }

        public DateTime OrderDateTime
        {
            get; set;
        }

        [ForeignKey(nameof(OrderDetail))]
        public int OrderDetailId { get; set; }
        public OrderDetail OrderDetail { get; set; }

        [ForeignKey(nameof(Branch))]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
