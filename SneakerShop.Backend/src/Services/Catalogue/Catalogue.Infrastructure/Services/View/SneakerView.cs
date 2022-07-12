using Catalogue.Application.Contracts.View;
using Catalogue.Application.Dto;
using Catalogue.Infrastructure.Dal;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static Catalogue.Domain.Constants.ResponseMessages;

namespace Catalogue.Infrastructure.Services.View
{
    public class SneakerView : ISneakerView
    {
        private readonly CatalogueContext _catalogueContext;
        public SneakerView(CatalogueContext catalogueContext)
        {
            _catalogueContext = catalogueContext;
        }
        public async Task<DataServiceMessage> GetAllSneakers()
        {
            var result = await _catalogueContext.Sneaker.ToListAsync();
            var data = new DataServiceMessage(true, GoodResponse.GetSuccessfully, result);
            return data;
        }

        public async Task<DataServiceMessage> GetSneakerById(int id)
        {
            var result = await _catalogueContext.Sneaker.FirstOrDefaultAsync(x => x.SneakerId == id);
            var data = new DataServiceMessage(true, GoodResponse.GetSuccessfully, result);
            return data;
        }

        public async Task<DataServiceMessage> GetSneakerByName(string name)
        {
            var result = await _catalogueContext.Sneaker.FirstOrDefaultAsync(x => x.Name == name);
            var data = new DataServiceMessage(true, GoodResponse.GetSuccessfully, result);
            return data;
        }

    }
}
