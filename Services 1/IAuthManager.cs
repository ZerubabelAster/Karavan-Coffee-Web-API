using KaravanCoffeeWebAPI.Models;

namespace KaravanCoffeeWebAPI.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginPersonDTO loginPersonDTO);

        Task<string> CreateToken();
    }
}
