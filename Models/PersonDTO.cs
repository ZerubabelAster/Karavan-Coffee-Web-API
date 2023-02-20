using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace KaravanCoffeeWebAPI.Models
{
    public class LoginByPhonePersonDTO
    {
        [Required]
        public string PhoneOREmail { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string? Password { get; set; }
    }
    public class LoginPersonDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
    public class UpdatePersonDTO : PersonDTO
    {

    }
    public class PersonDTO : LoginPersonDTO
    {
        public string FullName { get; set; }

        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }

        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }

        [Required]
        [RegularExpression(@"^\+(?:[0-9]●?){6,14}[0-9]$", ErrorMessage = "Phone number is not valid.")]
        public string PhoneNumber { get; set; }

        public string Role { get; set; }
    }
}
