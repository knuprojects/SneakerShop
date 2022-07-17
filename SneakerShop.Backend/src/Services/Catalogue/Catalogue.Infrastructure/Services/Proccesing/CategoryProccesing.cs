using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Dto;
using System;
using System.Threading.Tasks;

namespace Catalogue.Infrastructure.Services.Proccesing
{
    public class CategoryProccesing : ICategoryProccesing
    {
        public Task<DataServiceMessage> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            throw new NotImplementedException();
        }

        public Task<DataServiceMessage> DeleteCategoryAsync(DeleteCategoryDto deleteCategoryDto)
        {
            throw new NotImplementedException();
        }

        public Task<DataServiceMessage> UpdateCategoryAsync(UpDateCategoryDto upDateCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
