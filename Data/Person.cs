using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace KaravanCoffeeWebAPI.Data
{
    public class Person : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime  BirthDate { get; set; }
        public string Gender { get; set; }
        public string ImagePath { get; set; }
    }
}
