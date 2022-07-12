using Catalogue.Application.Dto;
using System.Threading.Tasks;

namespace Catalogue.Application.Contracts.View
{
    public interface ICategoryView
    {
        Task<DataServiceMessage> GetAllCategories();
        Task<DataServiceMessage> GetCategoryById(int id);
        Task<DataServiceMessage> GetCategoryByName(string name);
    }
}
