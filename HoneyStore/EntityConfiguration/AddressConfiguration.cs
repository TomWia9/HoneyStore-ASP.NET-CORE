using HoneyStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyStore.EntityConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.City)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(a => a.StreetAndHouseNumber)
              .IsRequired()
              .HasMaxLength(100);

            builder.Property(a => a.PostCode)
              .IsRequired()
              .HasMaxLength(25);

        }
    }
}
