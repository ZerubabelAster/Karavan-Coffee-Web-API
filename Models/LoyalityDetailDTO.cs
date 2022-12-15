using System.ComponentModel.DataAnnotations;

namespace KaravanCoffeeWebAPI.Models
{
    public class CreateLoyalityDetailDTO
    {
        public int Quantity { get; set; }

        [Required]
        public int LoyalityPoint { get; set; }

        public DateTime OrderDateTime
        {
            get; set;
        }
        [Required]
        public int PersonId { get; set; }

        [Required]
        public int OrderDetailId { get; set; }

        [Required]
        public int BranchId { get; set; }
    }
    public class UpdateLOyalityDetailDTO : CreateLoyalityDetailDTO
    {

    }
    public class LoyalityDetailDTO : CreateLoyalityDetailDTO
    {
        public int LoyalityId { get; set; }

        public PersonDTO Person { get; set; }
        public OrderDetailDTO OrderDetail { get; set; }
        public BranchDTO Branch { get; set; }
    }
}
