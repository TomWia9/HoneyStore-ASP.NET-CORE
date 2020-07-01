using Microsoft.EntityFrameworkCore;

namespace HoneyStore.Models
{
    public class HoneyStoreContext : DbContext
    {
        public HoneyStoreContext(DbContextOptions<HoneyStoreContext> options) : base(options)
        {
        }
    }
}
