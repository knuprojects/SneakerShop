using Catalogue.Domain.Entities;
using Catalogue.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogue.Infrastructure.Dal.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.CompanyId);
            builder.Property(x => x.Name)
                .HasConversion(x => x.Value, x => new Name(x))
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
