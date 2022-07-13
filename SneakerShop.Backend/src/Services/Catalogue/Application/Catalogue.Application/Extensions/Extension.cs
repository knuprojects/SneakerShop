using Catalogue.Application.Abstraction;
using Catalogue.Application.Dto;
using Catalogue.Application.Queries.Category.GetAll;
using Catalogue.Application.Queries.Category.GetById;
using Catalogue.Application.Queries.Category.GetByName;
using Catalogue.Application.Queries.Companies.GetAll;
using Catalogue.Application.Queries.Companies.GetById;
using Catalogue.Application.Queries.Companies.GetByName;
using Catalogue.Application.Queries.Sneakers.GetAll;
using Catalogue.Application.Queries.Sneakers.GetById;
using Catalogue.Application.Queries.Sneakers.GetByName;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogue.Application.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            #region Sneakers
            services.AddScoped<IQuery<DataServiceMessage>, GetSneakers>();
            services.AddScoped<IQuery<DataServiceMessage>, GetSneakersById>();
            services.AddScoped<IQuery<DataServiceMessage>, GetSneakersByName>();

            services.AddScoped<IQueryHandler<GetSneakers, DataServiceMessage>, GetSneakersHandler>();
            services.AddScoped<IQueryHandler<GetSneakersById, DataServiceMessage>, GetSneakersByIdHandler>();
            services.AddScoped<IQueryHandler<GetSneakersByName, DataServiceMessage>, GetSneakersByNameHandler>();
            #endregion

            #region Company
            services.AddScoped<IQuery<DataServiceMessage>, GetCompanies>();
            services.AddScoped<IQuery<DataServiceMessage>, GetCompaniesById>();
            services.AddScoped<IQuery<DataServiceMessage>, GetCompaniesByName>();

            services.AddScoped<IQueryHandler<GetCompanies, DataServiceMessage>, GetCompaniesHandler>();
            services.AddScoped<IQueryHandler<GetCompaniesById, DataServiceMessage>, GetCompaniesByIdHandler>();
            services.AddScoped<IQueryHandler<GetCompaniesByName, DataServiceMessage>, GetCompaniesByNameHandler>();
            #endregion

            #region Category
            services.AddScoped<IQuery<DataServiceMessage>, GetCategories>();
            services.AddScoped<IQuery<DataServiceMessage>, GetCategoriesById>();
            services.AddScoped<IQuery<DataServiceMessage>, GetCategoriesByName>();

            services.AddScoped<IQueryHandler<GetCategories, DataServiceMessage>, GetCategoriesHandler>();
            services.AddScoped<IQueryHandler<GetCategoriesById, DataServiceMessage>, GetCategoriesByIdHandler>();
            services.AddScoped<IQueryHandler<GetCategoriesByName, DataServiceMessage>, GetCategoriesByNameHandler>();
            #endregion

            return services;
        }
    }
}
