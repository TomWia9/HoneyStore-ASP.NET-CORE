using HoneyStore.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace HoneyStore.Models
{
    public class HoneyStoreContext : DbContext
    {
        public HoneyStoreContext(DbContextOptions<HoneyStoreContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<HoneyItem> HoneysInTheCart { get; set; }
        public DbSet<HoneyInTheWarehouse> HoneysInTheWarehouse { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new HoneyItemConfiguration());
            modelBuilder.ApplyConfiguration(new HoneyInTheWarehouseConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderedHoneysConfiguration());
        }
    }
}
