using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Dto;
using Catalogue.Application.Mapper;
using Catalogue.Infrastructure.Dal;
using Catalogue.Infrastructure.Exceptions;
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
            var mapper = Mapping.CreateCategoryDtoToCategory(createCategoryDto);

            await _catalogueContext.Category.AddAsync(mapper);
            await _catalogueContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.AddedSuccessfully, mapper);
            return data;
        }

        public async Task<DataServiceMessage> DeleteCategoryAsync(DeleteCategoryDto deleteCategoryDto)
        {
            var category = await _catalogueContext.Category.FirstOrDefaultAsync(x => x.CategoryId == deleteCategoryDto.CategoryId);

            if (category == null)
                throw new InvalidCategoryIdException(deleteCategoryDto.CategoryId);

            _catalogueContext.Category.Remove(category);
            await _catalogueContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.DeletedSuccessfully, category);
            return data;
        }

        public async Task<DataServiceMessage> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _catalogueContext.Category.AsNoTracking().FirstOrDefaultAsync(x => x.CategoryId == updateCategoryDto.CategoryId);

            if (category == null)
                throw new InvalidCategoryIdException(updateCategoryDto.CategoryId);

            var mapper = Mapping.UpdateCategoryDtoToCategory(updateCategoryDto);

            _catalogueContext.Category.Update(mapper);
            await _catalogueContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.UpdatedSuccessfully, mapper);
            return data;
        }
    }
}
