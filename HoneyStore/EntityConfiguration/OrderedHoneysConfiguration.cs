using HoneyStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyStore.EntityConfiguration
{
    public class OrderedHoneysConfiguration : IEntityTypeConfiguration<OrderedHoney>
    {
        public void Configure(EntityTypeBuilder<OrderedHoney> builder)
        {

            builder.ToTable("OrderedHoneys");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Name)
               .IsRequired()
               .HasMaxLength(80);

            builder.Property(h => h.Price)
              .IsRequired()
              .HasMaxLength(10)
              .HasColumnType("decimal(18, 4)");

            builder.Property(h => h.Amount)
               .IsRequired();
        }
    }
}
