using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.View;
using Catalogue.Application.Dto;
using System.Threading.Tasks;

namespace Catalogue.Application.Queries.Category.GetById
{
    public class GetCategoriesByIdHandler : IQueryHandler<GetCategoriesById, DataServiceMessage>
    {
        private readonly ICategoryView _categoryView;
        public GetCategoriesByIdHandler(ICategoryView categoryView)
        {
            _categoryView = categoryView;
        }
        public async Task<DataServiceMessage> HandleAsync(GetCategoriesById query)
        {
            return await _categoryView.GetCategoryById(query.CategoryId);
        }
    }
}
