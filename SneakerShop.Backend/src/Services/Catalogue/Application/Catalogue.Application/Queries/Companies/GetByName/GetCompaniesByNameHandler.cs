using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.View;
using Catalogue.Application.Dto;
using System.Threading.Tasks;

namespace Catalogue.Application.Queries.Companies.GetByName
{
    public class GetCompaniesByNameHandler : IQueryHandler<GetCompaniesByName, DataServiceMessage>
    {
        private readonly ICompanyView _companyView;
        public GetCompaniesByNameHandler(ICompanyView companyView)
        {
            _companyView = companyView;
        }
        public async Task<DataServiceMessage> HandleAsync(GetCompaniesByName query)
        {
            return await _companyView.GetCompanyByName(query.Name);
        }
    }
}
