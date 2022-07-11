using Catalogue.Domain.Entities;
using Catalogue.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogue.Infrastructure.Dal.Configurations
{
    public class SneakerConfiguration : IEntityTypeConfiguration<Sneaker>
    {
        public void Configure(EntityTypeBuilder<Sneaker> builder)
        {
            builder.HasKey(x => x.SneakerId);
            builder.Property(x => x.Name)
                .HasConversion(x => x.Value, x => new Name(x))
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Price)
                .HasConversion(x => x.Value, x => new Price(x))
                .IsRequired();
            builder.Property(x => x.Size)
                .HasConversion(x => x.Value, x => new Size(x))
                .IsRequired();
            builder.Property(x => x.Colour)
                .HasConversion(x => x.Value, x => new Colour(x))
                .IsRequired();
        }
    }
}
