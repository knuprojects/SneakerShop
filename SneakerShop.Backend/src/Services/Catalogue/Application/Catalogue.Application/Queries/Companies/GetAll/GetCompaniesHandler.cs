using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.View;
using Catalogue.Application.Dto;
using System.Threading.Tasks;

namespace Catalogue.Application.Queries.Companies.GetAll
{
    public class GetCompaniesHandler : IQueryHandler<GetCompanies, DataServiceMessage>
    {
        private readonly ICompanyView _companyView;
        public GetCompaniesHandler(ICompanyView companyView)
        {
            _companyView = companyView;
        }
        public async Task<DataServiceMessage> HandleAsync(GetCompanies query)
        {
            return await _companyView.GetAllCompanies();
        }
    }
}
