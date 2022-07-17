namespace Catalogue.Domain.Constants
{
    public static class Routes
    {
        #region Sneakers
        public const string GetAllSneakers = "sneakers";
        public const string GetAllSneakersById = "sneaker";
        public const string GetAllSneakersByName = "sneakerByName";
        #endregion

        #region Companies
        public const string GetAllCompanies = "companies";
        public const string GetAllCompanyById = "company";
        public const string GetAllCompanyByName = "companyByName";
        #endregion

        #region Categories
        public const string GetAllCategories = "categories";
        public const string GetAllCategoriesById = "category";
        public const string GetAllCategoriesByName = "categoryByName";
        #endregion

    }
}
