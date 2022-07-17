using Catalogue.Application.Dto;
using System.Threading.Tasks;

namespace Catalogue.Application.Contracts.Processing
{
    public interface ICompanyProccesing
    {
        Task<DataServiceMessage> CreateCompanyAsync(CreateCompanyDto createCompanyDto);
        Task<DataServiceMessage> UpdateCompanyAsync(UpDateCompanyDto updateCompanyDto);
        Task<DataServiceMessage> DeleteCompanyAsync(DeleteCompanyDto deleteCompanyDto);
    }
}
