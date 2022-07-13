using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.View;
using Catalogue.Application.Dto;
using System.Threading.Tasks;

namespace Catalogue.Application.Queries.Category.GetAll
{
    public class GetCategoriesHandler : IQueryHandler<GetCategories, DataServiceMessage>
    {
        private readonly ICategoryView _categoryView;
        public GetCategoriesHandler(ICategoryView categoryView)
        {
            _categoryView = categoryView;
        }
        public async Task<DataServiceMessage> HandleAsync(GetCategories query)
        {
            return await _categoryView.GetAllCategories();
        }
    }
}
