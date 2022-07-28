using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.View;
using Catalogue.Application.Dto;
using System.Threading.Tasks;

namespace Catalogue.Application.Queries.Sneakers.GetSorts
{
    public class GetSortedSneakersByPriceHandler : IQueryHandler<GetSortedSneakersByPrice, DataServiceMessage>
    {
        private readonly ISneakerView _sneakerView;
        public GetSortedSneakersByPriceHandler(ISneakerView sneakerView)
        {
            _sneakerView = sneakerView;
        }

        public async Task<DataServiceMessage> HandleAsync(GetSortedSneakersByPrice query)
        {
            return await _sneakerView.GetSortedSneakerByPrice(query.minPrice, query.maxPrice);
        }
    }
}
