using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Entities;
using Order.Domain.ValueObjects;

namespace Order.Infrastructure.Dal.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<AppOrder>
    {
        public void Configure(EntityTypeBuilder<AppOrder> builder)
        {
            builder.HasKey(e => e.OrderId);

            builder.Property(e => e.Login)
                   .HasConversion(e => e.Value, e => new Login(e))
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(e => e.TotalPrice)
                   .HasConversion(e => e.Value, e => new TotalPrice(e))
                   .IsRequired();

            builder.Property(e => e.FirstName)
                   .HasConversion(e => e.Value, e => new FirstName(e))
                   .IsRequired();

            builder.Property(e => e.LastName)
                   .HasConversion(e => e.Value, e => new LastName(e))
                   .IsRequired();

            builder.Property(e => e.Email)
                   .HasConversion(e => e.Value, e => new Email(e))
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.AddressLine)
                   .HasConversion(e => e.Value, e => new AddressLine(e))
                   .IsRequired();

            builder.Property(e => e.Country)
                   .HasConversion(e => e.Value, e => new Country(e))
                   .IsRequired();

            builder.Property(e => e.State)
                   .HasConversion(e => e.Value, e => new State(e))
                   .IsRequired();

            builder.Property(e => e.ZipCode)
                   .HasConversion(e => e.Value, e => new ZipCode(e))
                   .IsRequired();

            builder.Property(e => e.CardName)
                   .HasConversion(e => e.Value, e => new CardName(e))
                   .IsRequired();

            builder.Property(e => e.CardNumber)
                   .HasConversion(e => e.Value, e => new CardNumber(e))
                   .IsRequired();

            builder.Property(e => e.Expiration)
                   .HasConversion(e => e.Value, e => new Expiration(e))
                   .IsRequired();

            builder.Property(e => e.CVV)
                   .HasConversion(e => e.Value, e => new CVV(e))
                   .IsRequired();
        }
    }
}
