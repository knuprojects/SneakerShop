using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.View;
using Catalogue.Application.Dto;
using System;
using System.Threading.Tasks;

namespace Catalogue.Application.Queries.Sneakers.GetByName
{
    public class GetSneakersByNameHandler : IQueryHandler<GetSneakersByName, DataServiceMessage>
    {
        private readonly ISneakerView _sneakerView;
        public GetSneakersByNameHandler(ISneakerView sneakerView)
        {
            _sneakerView = sneakerView;
        }
        public async Task<DataServiceMessage> HandleAsync(GetSneakersByName query)
        {
            return await _sneakerView.GetSneakerByName(query.Name);
        }
    }
}
