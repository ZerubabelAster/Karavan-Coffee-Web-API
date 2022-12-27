namespace KaravanCoffeeWebAPI.IRepository
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
