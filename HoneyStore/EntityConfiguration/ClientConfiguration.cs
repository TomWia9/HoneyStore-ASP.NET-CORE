using HoneyStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoneyStore.EntityConfiguration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Address)
                   .WithOne(c => c.Client)
                   .HasForeignKey<Address>(c => c.ClientId);

            builder.Property(c => c.Email)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(c => c.Password)
              .IsRequired()
              .HasMaxLength(64);

            builder.Property(c => c.FirstName)
              .IsRequired()
              .HasMaxLength(25);

            builder.Property(c => c.LastName)
              .IsRequired()
              .HasMaxLength(25);
        }
    }
}
