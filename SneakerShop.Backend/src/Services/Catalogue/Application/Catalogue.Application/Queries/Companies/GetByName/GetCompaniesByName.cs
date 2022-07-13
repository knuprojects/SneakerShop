using Catalogue.Application.Abstraction;
using Catalogue.Application.Dto;

namespace Catalogue.Application.Queries.Companies.GetByName
{
    public class GetCompaniesByName : IQuery<DataServiceMessage>
    {
        public string Name { get; set; }
    }
}
