using Catalogue.Application.Contracts.View;
using Catalogue.Application.Dto;
using Catalogue.Infrastructure.Dal;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static Catalogue.Domain.Constants.ResponseMessages;

namespace Catalogue.Infrastructure.Services.View
{
    public class CategoryView : ICategoryView
    {
        private readonly CatalogueContext _catalogueContext;
        public CategoryView(CatalogueContext catalogueContext)
        {
            _catalogueContext = catalogueContext;
        }
        public async Task<DataServiceMessage> GetAllCategories()
        {
            var result = await _catalogueContext.Category.ToListAsync();
            var data = new DataServiceMessage(true, GoodResponse.GetSuccessfully, result);
            return data;
        }

        public async Task<DataServiceMessage> GetCategoryById(int id)
        {
            var result = await _catalogueContext.Category.FirstOrDefaultAsync(x => x.CategoryId == id);
            var data = new DataServiceMessage(true, GoodResponse.GetSuccessfully, result);
            return data;
        }

        public async Task<DataServiceMessage> GetCategoryByName(string name)
        {
            var result = await _catalogueContext.Category.FirstOrDefaultAsync(x => x.Name == name);
            var data = new DataServiceMessage(true, GoodResponse.GetSuccessfully, result);
            return data;
        }
    }
}
