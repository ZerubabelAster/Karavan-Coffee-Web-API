using KaravanCoffeeWebAPI.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaravanCoffeeWebAPI.Models
{
    public class CreateProductAvailabilityDTO
    {

        [Required]
        public int Quantity { get; set; }


        public int MinThreshold { get; set; }
        public int MaxThreshold { get; set; }

        [Required]
        public int BranchId { get; set; }

        [Required]  
        public int ProductId { get; set; }
    }

    public class UpdateProductAvailabilityDTO : CreateProductAvailabilityDTO
    {

    }
    public class ProductAvailabilityDTO : CreateProductAvailabilityDTO
    {
        public int ProductAvailabilityId { get; set; }

        public BranchDTO Branch { get; set; }
        public ProductDTO Product { get; set; }
    }
}
