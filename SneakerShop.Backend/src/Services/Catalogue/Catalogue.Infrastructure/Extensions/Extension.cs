using Catalogue.Application.Contracts.View;
using Catalogue.Infrastructure.Dal;
using Catalogue.Infrastructure.Services.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogue.Infrastructure.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<CatalogueContext>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Catalogue.Api"));
            });

            services.AddScoped<ISneakerView, SneakerView>();
            services.AddScoped<ICompanyView, CompanyView>();
            services.AddScoped<ICategoryView, CategoryView>();

            return services;
        }
    }
}
