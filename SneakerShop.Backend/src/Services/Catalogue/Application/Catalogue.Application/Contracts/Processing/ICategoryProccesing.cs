using Catalogue.Application.Dto;
using System.Threading.Tasks;

namespace Catalogue.Application.Contracts.Processing
{
    public interface ICategoryProccesing
    {
        Task<DataServiceMessage> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<DataServiceMessage> UpdateCategoryAsync(UpDateCategoryDto upDateCategoryDto);
        Task<DataServiceMessage> DeleteCategoryAsync(DeleteCategoryDto deleteCategoryDto);
    }
}
