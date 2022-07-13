using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.View;
using Catalogue.Application.Dto;
using System.Threading.Tasks;

namespace Catalogue.Application.Queries.Sneakers.GetById
{
    public class GetSneakersByIdHandler : IQueryHandler<GetSneakersById, DataServiceMessage>
    {
        private readonly ISneakerView _sneakerView;
        public GetSneakersByIdHandler(ISneakerView sneakerView)
        {
            _sneakerView = sneakerView;
        }
        public async Task<DataServiceMessage> HandleAsync(GetSneakersById query)
        {
            return await _sneakerView.GetSneakerById(query.SneakerId);
        }
    }
}
