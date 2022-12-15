using Microsoft.AspNetCore.Identity;

namespace KaravanCoffeeWebAPI.Data
{
    public class Person : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}
