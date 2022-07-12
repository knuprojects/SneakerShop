using Catalogue.Application.Dto;
using System.Threading.Tasks;

namespace Catalogue.Application.Contracts.View
{
    public interface ICompanyView
    {
        Task<DataServiceMessage> GetAllCompanies();
        Task<DataServiceMessage> GetCompanyById(int id);
        Task<DataServiceMessage> GetCompanyByName(string name);
    }
}
