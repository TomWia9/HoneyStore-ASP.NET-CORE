using HoneyStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyStore.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.TotalPrice)
              .IsRequired()
              .HasColumnType("decimal(18, 4)");

            builder.Property(o => o.Delivery)
                .IsRequired();

            builder.Property(o => o.Payment)
                .IsRequired();

            builder.Property(o => o.Date)
                .IsRequired();
        }
    }
}
