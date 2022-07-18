using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Dto;
using Catalogue.Application.Mapper;
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

            var mapper = Mapping.UpdateCategoryDtoToCategory(upDateCategoryDto);

            _catalogueContext.Category.Update(mapper);
            await _catalogueContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.UpdatedSuccessfully, mapper);
            return data;
        }
    }
}
