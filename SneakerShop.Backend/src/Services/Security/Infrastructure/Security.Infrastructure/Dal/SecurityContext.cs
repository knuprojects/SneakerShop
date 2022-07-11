using Microsoft.EntityFrameworkCore;
using Security.Domain.Entities;

namespace Security.Infrastructure.Dal
{
    public class SecurityContext : DbContext
    {
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }

        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_RefreshTokens_UserId");
            });

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
