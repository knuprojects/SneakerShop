using Catalogue.Application.Contracts.View;
using Catalogue.Application.Dto;
using Catalogue.Infrastructure.Dal;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
            var result = await _catalogueContext.Category.Join(_catalogueContext.Company,
                c => c.CompanyId,
                i => i.CompanyId,
                (c, i) =>
                new
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                    Deleted = c.Deleted,
                    CompanyName = i.Name,
                    Sneakers = c.Sneakers.Where(e => e.CategoryId == c.CategoryId).ToList(),
                }).ToListAsync();
            var data = new DataServiceMessage(true, GoodResponse.GetSuccessfully, result);
            return data;
        }

        public async Task<DataServiceMessage> GetCategoryById(int id)
        {
            var result = await _catalogueContext.Category.Join(_catalogueContext.Company,
                c => c.CompanyId,
                i => i.CompanyId,
                (c, i) =>
                new
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                    Deleted = c.Deleted,
                    CompanyName = i.Name,
                    Sneakers = c.Sneakers.Where(e => e.CategoryId == c.CategoryId).ToList(),
                }).FirstOrDefaultAsync(x => x.CategoryId == id);
            var data = new DataServiceMessage(true, GoodResponse.GetSuccessfully, result);
            return data;
        }

        public async Task<DataServiceMessage> GetCategoryByName(string name)
        {
            var result = await _catalogueContext.Category.Join(_catalogueContext.Company,
                c => c.CompanyId,
                i => i.CompanyId,
                (c, i) =>
                new
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                    Deleted = c.Deleted,
                    CompanyName = i.Name,
                    Sneakers = c.Sneakers.Where(e => e.CategoryId == c.CategoryId).ToList(),
                }).FirstOrDefaultAsync(x => x.Name == name);
            var data = new DataServiceMessage(true, GoodResponse.GetSuccessfully, result);
            return data;
        }
    }
}
