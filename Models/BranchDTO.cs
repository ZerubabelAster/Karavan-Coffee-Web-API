using System.ComponentModel.DataAnnotations;
using KaravanCoffeeWebAPI.Data;

namespace KaravanCoffeeWebAPI.Models
{

    public class CreateBranchDTO
    {
        [Required]
        [StringLength(50, ErrorMessage = "Branch Name is too long.")]
        public string BranchName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Branch Address Name is too long.")]
        public string BranchAddress { get; set; }
    }
    
    public class UpdateBranchDTO : CreateBranchDTO
    {

    }

    public class BranchDTO : CreateBranchDTO
    {
        public int BranchId { get; set; }
    }



}
