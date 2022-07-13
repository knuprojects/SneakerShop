using Catalogue.Application.Abstraction;
using Catalogue.Application.Dto;

namespace Catalogue.Application.Queries.Companies.GetById
{
    public class GetCompaniesById : IQuery<DataServiceMessage>
    {
        public int CompanyId { get; set; }
    }
}
