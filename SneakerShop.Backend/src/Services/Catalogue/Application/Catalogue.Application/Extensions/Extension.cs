using Catalogue.Application.Abstraction;
using Catalogue.Application.Commands.Category.CreateCategory;
using Catalogue.Application.Commands.Category.DeleteCategory;
using Catalogue.Application.Commands.Category.UpdateCategory;
using Catalogue.Application.Commands.Companies.CreateCompany;
using Catalogue.Application.Commands.Companies.DeleteCompany;
using Catalogue.Application.Commands.Companies.UpdateCompany;
using Catalogue.Application.Commands.Sneakers.CreateSneaker;
using Catalogue.Application.Commands.Sneakers.DeleteSneaker;
using Catalogue.Application.Commands.Sneakers.UpdateSneaker;
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
using Catalogue.Application.Queries.Sneakers.GetSorts;
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
            services.AddScoped<IQuery<DataServiceMessage>, GetSortedSneakersByPrice>();

            services.AddScoped<IQueryHandler<GetSneakers, DataServiceMessage>, GetSneakersHandler>();
            services.AddScoped<IQueryHandler<GetSneakersById, DataServiceMessage>, GetSneakersByIdHandler>();
            services.AddScoped<IQueryHandler<GetSneakersByName, DataServiceMessage>, GetSneakersByNameHandler>();
            services.AddScoped<IQueryHandler<GetSortedSneakersByPrice, DataServiceMessage>, GetSortedSneakersByPriceHandler>();

            services.AddScoped<ICommand, CreateSneakerCommand>();
            services.AddScoped<ICommand, UpdateSneakerCommand>();
            services.AddScoped<ICommand, DeleteSneakerCommand>();

            services.AddScoped<ICommandHandler<CreateSneakerCommand>, CreateSneakerCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateSneakerCommand>, UpdateSneakerCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteSneakerCommand>, DeleteSneakerCommandHandler>();
            #endregion

            #region Company
            services.AddScoped<IQuery<DataServiceMessage>, GetCompanies>();
            services.AddScoped<IQuery<DataServiceMessage>, GetCompaniesById>();
            services.AddScoped<IQuery<DataServiceMessage>, GetCompaniesByName>();

            services.AddScoped<IQueryHandler<GetCompanies, DataServiceMessage>, GetCompaniesHandler>();
            services.AddScoped<IQueryHandler<GetCompaniesById, DataServiceMessage>, GetCompaniesByIdHandler>();
            services.AddScoped<IQueryHandler<GetCompaniesByName, DataServiceMessage>, GetCompaniesByNameHandler>();


            services.AddScoped<ICommand, CreateCompanyCommand>();
            services.AddScoped<ICommand, UpdateCompanyCommand>();
            services.AddScoped<ICommand, DeleteCompanyCommand>();

            services.AddScoped<ICommandHandler<CreateCompanyCommand>, CreateCompanyCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateCompanyCommand>, UpdateCompanyCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteCompanyCommand>, DeleteCompanyCommandHandler>();

            #endregion

            #region Category
            services.AddScoped<IQuery<DataServiceMessage>, GetCategories>();
            services.AddScoped<IQuery<DataServiceMessage>, GetCategoriesById>();
            services.AddScoped<IQuery<DataServiceMessage>, GetCategoriesByName>();

            services.AddScoped<IQueryHandler<GetCategories, DataServiceMessage>, GetCategoriesHandler>();
            services.AddScoped<IQueryHandler<GetCategoriesById, DataServiceMessage>, GetCategoriesByIdHandler>();
            services.AddScoped<IQueryHandler<GetCategoriesByName, DataServiceMessage>, GetCategoriesByNameHandler>();

            services.AddScoped<ICommand, CreateCategoryCommand>();
            services.AddScoped<ICommand, DeleteCategoryCommand>();
            services.AddScoped<ICommand, UpdateCategoryCommand>();

            services.AddScoped<ICommandHandler<CreateCategoryCommand>, CreateCategoryCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteCategoryCommand>, DeleteCategoryCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateCategoryCommand>, UpdateCategoryCommandHandler>();

            #endregion

            return services;
        }
    }
}
