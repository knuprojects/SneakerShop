using Catalogue.Application.Dto;
using System.Threading.Tasks;

namespace Catalogue.Application.Contracts.Processing
{
    public interface ISneakerProccesing
    {
        Task<DataServiceMessage> CreateSneakerAsync(CreateSneakerDto createSneakerDto);
        Task<DataServiceMessage> UpdateSneakerAsync(UpDateSneakerDto upDateSneakerDto);
        Task<DataServiceMessage> DeleteSneakerAsync(DeleteSneakerDto deleteSneakerDto);
    }
}
