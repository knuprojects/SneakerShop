using Catalogue.Application.Abstraction;
using Catalogue.Application.Dto;

namespace Catalogue.Application.Queries.Sneakers.GetByName
{
    public class GetSneakersByName : IQuery<DataServiceMessage>
    {
        public string Name { get; set; }
    }
}
