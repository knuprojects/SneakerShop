using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.View;
using Catalogue.Application.Dto;
using System.Threading.Tasks;

namespace Catalogue.Application.Queries.Companies.GetById
{
    public class GetCompaniesByIdHandler : IQueryHandler<GetCompaniesById, DataServiceMessage>
    {
        private readonly ICompanyView _companyView;
        public GetCompaniesByIdHandler(ICompanyView companyView)
        {
            _companyView = companyView;
        }
        public async Task<DataServiceMessage> HandleAsync(GetCompaniesById query)
        {
            return await _companyView.GetCompanyById(query.CompanyId);
        }
    }
}
