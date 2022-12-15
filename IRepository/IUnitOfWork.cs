using KaravanCoffeeWebAPI.Data;

namespace KaravanCoffeeWebAPI.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Branch> Branches { get; }

        IGenericRepository<Order> Orders { get; }

        IGenericRepository<OrderDetail> OrdersDetail { get; }

        IGenericRepository<Product> Products { get; }

        IGenericRepository<ProductAvailability> ProductAvailabilities { get; }

        IGenericRepository<LoyalityDetail> LoyaltiesDetail { get; }

        Task Save();
    }
}
