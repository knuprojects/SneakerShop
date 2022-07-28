using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Contracts.View;
using Catalogue.Domain.Entities;
using Catalogue.Infrastructure.Dal;
using Catalogue.Infrastructure.Services.Proccesing;
using Catalogue.Infrastructure.Services.Sortings;
using Catalogue.Infrastructure.Services.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Infrastructure.Exceptions.Middleware;

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

            services.AddSingleton<ExceptionMiddleware>();


            services.AddScoped<ISortByFilters<Sneaker>, SortByFilters<Sneaker>>();
            services.AddScoped<ISneakerView, SneakerView>();
            services.AddScoped<ICompanyView, CompanyView>();
            services.AddScoped<ICategoryView, CategoryView>();

            services.AddScoped<ICompanyProccesing, CompanyProccesing>();
            services.AddScoped<ICategoryProccesing, CategoryProccesing>();
            services.AddScoped<ISneakerProccesing, SneakerProccesing>();

            return services;
        }
    }
}
