using HoneyStore.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyStore.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new HoneyStoreContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HoneyStoreContext>>());
            if (context.Clients.Where(x => x.Email == "admin@admin").Any())
            {
                return;   // DB has been seeded
            }

            context.Clients.Add(
                new Client
                {
                    Email = "admin@admin",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Password = Hash.GetHash("admin")
                }
            );
            context.SaveChanges();
        }
    }
}
