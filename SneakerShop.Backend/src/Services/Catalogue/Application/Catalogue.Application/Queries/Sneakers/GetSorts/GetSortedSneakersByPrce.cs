using Catalogue.Application.Abstraction;
using Catalogue.Application.Dto;

namespace Catalogue.Application.Queries.Sneakers.GetSorts
{
    public class GetSortedSneakersByPrice : IQuery<DataServiceMessage>
    {
        public decimal minPrice { get; set; }
        public decimal maxPrice { get; set; }
    }
}
