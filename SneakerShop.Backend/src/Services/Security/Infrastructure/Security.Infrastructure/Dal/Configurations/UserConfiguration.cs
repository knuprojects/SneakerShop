using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Domain.Entities;
using Security.Domain.ValueObjects;

namespace Security.Infrastructure.Dal.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Email)
                .HasConversion(x => x.Value, x => new Email(x))
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(x => x.Login).IsUnique();
            builder.Property(x => x.Login)
                .HasConversion(x => x.Value, x => new Login(x))
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x => x.Password)
                .HasConversion(x => x.Value, x => new Password(x))
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(x => x.Role)
                .HasConversion(x => x.Value, x => new Role(x))
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(x => x.CreatedAt).IsRequired();
        }
    }
}
