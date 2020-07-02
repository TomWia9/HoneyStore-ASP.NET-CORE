using HoneyStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyStore.EntityConfiguration
{
    public class HoneyItemConfiguration : IEntityTypeConfiguration<HoneyItem>
    {
        public void Configure(EntityTypeBuilder<HoneyItem> builder)
        {
            builder.ToTable("HoneysInTheCart");
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Name)
               .IsRequired()
               .HasMaxLength(80);

            builder.Property(h => h.Price)
              .IsRequired()
              .HasMaxLength(10)
              .HasColumnType("decimal(18, 4)");
        }
    }
}
