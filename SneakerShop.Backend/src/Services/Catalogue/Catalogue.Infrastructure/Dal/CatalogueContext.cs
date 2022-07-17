using Catalogue.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalogue.Infrastructure.Dal
{
    public class CatalogueContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Sneaker> Sneaker { get; set; }

        public CatalogueContext(DbContextOptions<CatalogueContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sneaker>(entity =>
            {
                entity.HasOne(d => d.Category)
                .WithMany(p => p.Sneakers)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Sneakers_CategoryId");

                entity.HasOne(d => d.Company)
                .WithMany(p => p.Sneakers)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_Sneakers_CompanyId");
            });

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
