using System.ComponentModel.DataAnnotations.Schema;

namespace KaravanCoffeeWebAPI.Data
{
    public class ProductAvailability
    {
        public int ProductAvailabilityId { get; set; }

        public int Quantity { get; set; }
        public int MinThreshold { get; set; }
        public int MaxThreshold { get; set; }

        [ForeignKey(nameof(Branch))]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
