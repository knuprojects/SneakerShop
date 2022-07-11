using Catalogue.Domain.Entities;
using Catalogue.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogue.Infrastructure.Dal.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.Name)
                .HasConversion(x => x.Value, x => new Name(x))
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
