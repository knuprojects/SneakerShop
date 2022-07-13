namespace Catalogue.Domain.Constants
{
    public static class Routes
    {
        #region Sneakers
        public const string GetAllSneakers = "sneakers";
        public const string GetAllSneakersById = "sneakers/{id}";
        public const string GetAllSneakersByName = "sneakers/{name}";
        #endregion

        #region Companies
        public const string GetAllCompanies = "companies";
        public const string GetAllCompanyById = "companies/{id}";
        public const string GetAllCompanyByName = "companies/{name}";
        #endregion

        #region Categories
        public const string GetAllCategories = "categories";
        public const string GetAllCategoriesById = "categories/{id}";
        public const string GetAllCategoriesByName = "categories/{name}";
        #endregion

    }
}
