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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }
    }
}
