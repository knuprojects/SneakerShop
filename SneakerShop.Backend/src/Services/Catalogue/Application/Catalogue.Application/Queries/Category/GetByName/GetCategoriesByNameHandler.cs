using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.View;
using Catalogue.Application.Dto;
using System.Threading.Tasks;

namespace Catalogue.Application.Queries.Category.GetByName
{
    public class GetCategoriesByNameHandler : IQueryHandler<GetCategoriesByName, DataServiceMessage>
    {
        private readonly ICategoryView _categoryView;
        public GetCategoriesByNameHandler(ICategoryView categoryView)
        {
            _categoryView = categoryView;
        }
        public async Task<DataServiceMessage> HandleAsync(GetCategoriesByName query)
        {
            return await _categoryView.GetCategoryByName(query.Name);
        }
    }
}
