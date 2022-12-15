using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.IRepository;

namespace KaravanCoffeeWebAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        IGenericRepository<Branch> _branches;
        IGenericRepository<Order> _orders;
        IGenericRepository<OrderDetail> _ordersDetail;
        IGenericRepository<Product> _products;
        IGenericRepository<ProductAvailability> _productAvailabilities;
        IGenericRepository<LoyalityDetail> _loyalityDetail;
        
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;

        }
        public IGenericRepository<Branch> Branches => _branches ??= new GenericRepository<Branch>(_context);

        public IGenericRepository<Order> Orders => _orders ??= new GenericRepository<Order>(_context);

        public IGenericRepository<OrderDetail> OrdersDetail => _ordersDetail ??= new GenericRepository<OrderDetail>(_context);

        public IGenericRepository<Product> Products => _products ??= new GenericRepository<Product>(_context);

        public IGenericRepository<ProductAvailability> ProductAvailabilities => _productAvailabilities ??= new GenericRepository<ProductAvailability>(_context);

        public IGenericRepository<LoyalityDetail> LoyaltiesDetail => _loyalityDetail ??= new GenericRepository<LoyalityDetail>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
