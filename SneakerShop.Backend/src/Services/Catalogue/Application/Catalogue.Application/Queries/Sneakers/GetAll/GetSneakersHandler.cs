using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.View;
using Catalogue.Application.Dto;
using System.Threading.Tasks;

namespace Catalogue.Application.Queries.Sneakers.GetAll
{
    public class GetSneakersHandler : IQueryHandler<GetSneakers, DataServiceMessage>
    {
        private readonly ISneakerView _sneakerView;
        public GetSneakersHandler(ISneakerView sneakerView)
        {
            _sneakerView = sneakerView;
        }
        public async Task<DataServiceMessage> HandleAsync(GetSneakers query)
        {
            return await _sneakerView.GetAllSneakers();
        }
    }
}
