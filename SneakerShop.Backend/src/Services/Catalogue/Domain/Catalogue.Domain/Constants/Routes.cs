namespace Catalogue.Domain.Constants
{
    public static class Routes
    {
        #region Sneakers
        public const string GetAllSneakers = "sneakers";
        public const string GetAllSneakersById = "sneaker";
        public const string GetAllSneakersByName = "sneakerByName";
        public const string GetAllSortedSneakersByPrice = "sneakerSortedByPrice";

        public const string CreateSneaker = "createSneaker";
        public const string UpdateSneaker = "updateSneaker";
        public const string DeleteSneaker = "DeleteSneaker";
        #endregion

        #region Companies
        public const string GetAllCompanies = "companies";
        public const string GetAllCompanyById = "company";
        public const string GetAllCompanyByName = "companyByName";

        public const string CreateCompany = "createCompany";
        public const string UpdateCompany = "updateCompany";
        public const string DeleteCompany = "deleteCompany";
        #endregion

        #region Categories
        public const string GetAllCategories = "categories";
        public const string GetAllCategoriesById = "category";
        public const string GetAllCategoriesByName = "categoryByName";

        public const string CreateCategory = "createCategory";
        public const string UpdateCategory = "updateCategory";
        public const string DeleteCategory = "deleteCategory";
        #endregion

    }
}
