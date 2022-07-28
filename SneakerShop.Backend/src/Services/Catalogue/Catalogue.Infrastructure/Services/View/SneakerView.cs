using Catalogue.Application.Contracts.View;
using Catalogue.Application.Dto;
using Catalogue.Domain.Entities;
using Catalogue.Infrastructure.Dal;
using Catalogue.Infrastructure.Services.Sortings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Catalogue.Domain.Constants.ResponseMessages;

namespace Catalogue.Infrastructure.Services.View
{
    public class SneakerView : ISneakerView
    {
        private readonly CatalogueContext _catalogueContext;
        private readonly ISortByFilters<Sneaker> _sortByFilters;
        public SneakerView(CatalogueContext catalogueContext, ISortByFilters<Sneaker> sortByFilters)
        {
            _catalogueContext = catalogueContext;
            _sortByFilters = sortByFilters;
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
        public async Task<DataServiceMessage> GetSortedSneakerByPrice(decimal minPrice, decimal maxPrice)
        {
            List<Sneaker> sneakers = await _catalogueContext.Sneaker.ToListAsync();
            var diapason = _sortByFilters.GetDiapasonByFilter(sneakers, minPrice, maxPrice);
            var result = _sortByFilters.Swap(diapason);
            var data = new DataServiceMessage(true, GoodResponse.GetSuccessfully, result);
            return data;
        }

    }
}
