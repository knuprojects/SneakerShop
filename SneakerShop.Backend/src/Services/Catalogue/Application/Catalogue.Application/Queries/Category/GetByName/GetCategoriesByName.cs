using Catalogue.Application.Abstraction;
using Catalogue.Application.Dto;

namespace Catalogue.Application.Queries.Category.GetByName
{
    public class GetCategoriesByName : IQuery<DataServiceMessage>
    {
        public string Name { get; set; }
    }
}
