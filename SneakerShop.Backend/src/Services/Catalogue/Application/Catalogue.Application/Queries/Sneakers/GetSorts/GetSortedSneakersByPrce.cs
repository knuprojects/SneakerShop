using Catalogue.Application.Abstraction;
using Catalogue.Application.Dto;

namespace Catalogue.Application.Queries.Sneakers.GetSorts
{
    public class GetSortedSneakersByPrice : IQuery<DataServiceMessage>
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
