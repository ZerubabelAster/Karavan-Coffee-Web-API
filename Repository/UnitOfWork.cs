using KaravanCoffeeWebAPI.Data;
using KaravanCoffeeWebAPI.IRepository;

namespace KaravanCoffeeWebAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        IGenericRepository<Branch> _branches;
        IGenericRepository<Order> _orders;
        IGenericRepository<OrderDetail> _ordersDetail;
        IGenericRepository<Product> _products;
        IGenericRepository<ProductAvailability> _productAvailabilities;
        IGenericRepository<LoyalityDetail> _loyalityDetail;
        IGenericRepository<Category> _categories;
        IGenericRepository<SubCategory> _subCategories;
        IGenericRepository<Gallery> _galleries;
        IGenericRepository<Ingredient> _ingredients;
        IGenericRepository<Person> _persons;

        public UnitOfWork(DatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IGenericRepository<Branch> Branches => _branches ??= new GenericRepository<Branch>(_context, _webHostEnvironment);

        public IGenericRepository<Order> Orders => _orders ??= new GenericRepository<Order>(_context, _webHostEnvironment);

        public IGenericRepository<OrderDetail> OrdersDetail => _ordersDetail ??= new GenericRepository<OrderDetail>(_context, _webHostEnvironment);

        public IGenericRepository<Product> Products => _products ??= new GenericRepository<Product>(_context, _webHostEnvironment);

        public IGenericRepository<ProductAvailability> ProductAvailabilities => _productAvailabilities ??= new GenericRepository<ProductAvailability>(_context, _webHostEnvironment);

        public IGenericRepository<LoyalityDetail> LoyaltiesDetail => _loyalityDetail ??= new GenericRepository<LoyalityDetail>(_context, _webHostEnvironment);

        public IGenericRepository<Category> Categories => _categories ??= new GenericRepository<Category>(_context, _webHostEnvironment);

        public IGenericRepository<SubCategory> SubCategories => _subCategories ??= new GenericRepository<SubCategory>(_context, _webHostEnvironment);

        public IGenericRepository<Gallery> Galleries => _galleries ??= new GenericRepository<Gallery>(_context, _webHostEnvironment);

        public IGenericRepository<Ingredient> Ingredients => _ingredients ??= new GenericRepository<Ingredient>(_context, _webHostEnvironment);

        public IGenericRepository<Person> Persons => _persons ??= new GenericRepository<Person>(_context, _webHostEnvironment);

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
