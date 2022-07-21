using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Dto;
using Catalogue.Application.Mapper;
using Catalogue.Infrastructure.Exceptions;
using Catalogue.Infrastructure.Dal;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static Catalogue.Domain.Constants.ResponseMessages;

namespace Catalogue.Infrastructure.Services.Proccesing
{
    public class SneakerProccesing : ISneakerProccesing
    {
        private readonly CatalogueContext _catalogueContext;
        public SneakerProccesing(CatalogueContext catalogueContext)
        {
            _catalogueContext = catalogueContext;
        }
        public async Task<DataServiceMessage> CreateSneakerAsync(CreateSneakerDto createSneakerDto)
        {
            var mapper = Mapping.CreateSneakerDtoToSneaker(createSneakerDto);

            await _catalogueContext.Sneaker.AddAsync(mapper);
            await _catalogueContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.AddedSuccessfully, mapper);
            return data;
        }

        public async Task<DataServiceMessage> DeleteSneakerAsync(DeleteSneakerDto deleteSneakerDto)
        {
            var sneaker = await _catalogueContext.Sneaker.FirstOrDefaultAsync(x => x.SneakerId == deleteSneakerDto.SneakerId);

            if (sneaker == null)
                throw new InvalidSneakerException(deleteSneakerDto.SneakerId);

            _catalogueContext.Sneaker.Remove(sneaker);
            await _catalogueContext.SaveChangesAsync();

            var result = new DataServiceMessage(true, GoodResponse.DeletedSuccessfully, sneaker);
            return result;
        }

        public async Task<DataServiceMessage> UpdateSneakerAsync(UpDateSneakerDto upDateSneakerDto)
        {
            var sneaker = await _catalogueContext.Sneaker.AsNoTracking().FirstOrDefaultAsync(x => x.SneakerId == upDateSneakerDto.SneakerId);

            if (sneaker == null)
                throw new InvalidSneakerException(upDateSneakerDto.SneakerId);

            var mapper = Mapping.UpdateSneakerDtoToSneaker(upDateSneakerDto);

            _catalogueContext.Sneaker.Update(mapper);
            await _catalogueContext.SaveChangesAsync();

            var result = new DataServiceMessage(true, GoodResponse.UpdatedSuccessfully, mapper);
            return result;
        }
    }
}
