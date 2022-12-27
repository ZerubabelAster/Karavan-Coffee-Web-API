using KaravanCoffeeWebAPI.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KaravanCoffeeWebAPI.Data
{
    public class DatabaseContext : IdentityDbContext<Person>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<ProductAvailability> ProductAvailability { get; set; }
        public DbSet<LoyalityDetail> LoyalityDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new SubCategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());

        }  
    }
}
