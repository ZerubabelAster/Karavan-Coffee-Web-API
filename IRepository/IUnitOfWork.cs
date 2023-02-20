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

        IGenericRepository<Category> Categories { get; }

        IGenericRepository<SubCategory> SubCategories { get; }

        IGenericRepository<Gallery> Galleries { get; }

        IGenericRepository<Ingredient> Ingredients { get; }

        IGenericRepository<Person> Persons { get; }

        Task Save();
    }
}
