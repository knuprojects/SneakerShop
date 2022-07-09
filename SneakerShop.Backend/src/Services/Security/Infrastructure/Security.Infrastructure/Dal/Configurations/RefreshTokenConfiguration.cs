using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Domain.Entities;
using Security.Domain.ValueObjects;

namespace Security.Infrastructure.Dal.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(x => x.RefreshTokenId);

            builder.Property(x => x.Token)
                .HasConversion(x => x.Value, x => new Token(x))
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
