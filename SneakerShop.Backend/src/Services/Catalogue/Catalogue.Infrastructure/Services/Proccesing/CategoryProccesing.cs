using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Dto;
using Catalogue.Domain.Entities;
using Catalogue.Domain.Exceptions;
using Catalogue.Infrastructure.Dal;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static Catalogue.Domain.Constants.ResponseMessages;

namespace Catalogue.Infrastructure.Services.Proccesing
{
    public class CategoryProccesing : ICategoryProccesing
    {
        private readonly CatalogueContext _catalogueContext;
        public CategoryProccesing(CatalogueContext catalogueContext)
        {
            _catalogueContext = catalogueContext;
        }

        public async Task<DataServiceMessage> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = new Category
            {
                Name = createCategoryDto.Name,
                Deleted = createCategoryDto.Deleted,
                CompanyId = createCategoryDto.CompanyId
            };

            await _catalogueContext.Category.AddAsync(category);
            await _catalogueContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.AddedSuccessfully, category);
            return data;
        }

        public async Task<DataServiceMessage> DeleteCategoryAsync(DeleteCategoryDto deleteCategoryDto)
        {
            var category = await _catalogueContext.Category.FirstOrDefaultAsync(x => x.CategoryId == deleteCategoryDto.CategoryId);

            if (category == null)
                throw new InvalidCategoryException(deleteCategoryDto.CategoryId);

            _catalogueContext.Category.Remove(category);
            await _catalogueContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.DeletedSuccessfully, category);
            return data;
        }

        public async Task<DataServiceMessage> UpdateCategoryAsync(UpDateCategoryDto upDateCategoryDto)
        {
            var category = await _catalogueContext.Category.AsNoTracking().FirstOrDefaultAsync(x => x.CategoryId == upDateCategoryDto.CategoryId);

            if (category == null)
                throw new InvalidCategoryException(upDateCategoryDto.CategoryId);

            var newCategory = new Category
            {
                CategoryId = upDateCategoryDto.CategoryId,
                Name = upDateCategoryDto.Name,
                Deleted = upDateCategoryDto.Deleted,
                CompanyId = upDateCategoryDto.CompanyId
            };

            _catalogueContext.Category.Update(newCategory);
            await _catalogueContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.UpdatedSuccessfully, newCategory);
            return data;
        }
    }
}
