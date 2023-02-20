namespace KaravanCoffeeWebAPI.Services
{
    public interface IAuthManager
    {
        Task<bool> IsUserRegistered(string PhoneOREmail);
        Task<bool> ValidateUser(string PhoneOREmail, string password);

        Task<string> CreateToken();
    }
}
