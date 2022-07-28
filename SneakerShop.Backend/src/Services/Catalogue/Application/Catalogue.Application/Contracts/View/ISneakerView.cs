using Catalogue.Application.Dto;
using System.Threading.Tasks;

namespace Catalogue.Application.Contracts.View
{
    public interface ISneakerView
    {
        Task<DataServiceMessage> GetAllSneakers();
        Task<DataServiceMessage> GetSneakerById(int id);
        Task<DataServiceMessage> GetSneakerByName(string name);
        Task<DataServiceMessage> GetSortedSneakerByPrice(decimal minPrice, decimal maxPrice);
        //Task<DataServiceMessage> GetSneakerBySize(double name);
        //Task<DataServiceMessage> GetSneakerByColour(string name);
    }
}
