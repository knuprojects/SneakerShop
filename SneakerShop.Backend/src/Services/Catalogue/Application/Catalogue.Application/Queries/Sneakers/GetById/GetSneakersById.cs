using Catalogue.Application.Abstraction;
using Catalogue.Application.Dto;

namespace Catalogue.Application.Queries.Sneakers.GetById
{
    public class GetSneakersById : IQuery<DataServiceMessage>
    {
        public int SneakerId { get; set; }
    }
}
