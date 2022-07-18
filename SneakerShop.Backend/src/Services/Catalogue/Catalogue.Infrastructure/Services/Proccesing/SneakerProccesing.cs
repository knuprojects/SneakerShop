using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Dto;
using Catalogue.Application.Mapper;
using Catalogue.Domain.Entities;
using Catalogue.Domain.Exceptions;
using Catalogue.Infrastructure.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
            //var sneaker = new Sneaker
            //{
            //    Name = createSneakerDto.Name,
            //    Price = createSneakerDto.Price,
            //    Size = createSneakerDto.Size,
            //    Colour = createSneakerDto.Colour,
            //    PhotoUrl = createSneakerDto.PhotoUrl,
            //    IsFavourite = createSneakerDto.IsFavourite,
            //    Deleted = createSneakerDto.Deleted,
            //    CategoryId = createSneakerDto.CategoryId,
            //    CompanyId = createSneakerDto.CompanyId,
            //};

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

            var newSneaker = new Sneaker
            {
                SneakerId = upDateSneakerDto.SneakerId,
                Name = upDateSneakerDto.Name,
                Price = upDateSneakerDto.Price,
                Size = upDateSneakerDto.Size,
                Colour = upDateSneakerDto.Colour,
                PhotoUrl = upDateSneakerDto.PhotoUrl,
                IsFavourite = upDateSneakerDto.IsFavourite,
                Deleted = upDateSneakerDto.Deleted,
                CategoryId = upDateSneakerDto.CategoryId,
                CompanyId = upDateSneakerDto.CompanyId,
            };

            _catalogueContext.Sneaker.Update(newSneaker);
            await _catalogueContext.SaveChangesAsync();

            var result = new DataServiceMessage(true, GoodResponse.UpdatedSuccessfully, newSneaker);
            return result;
        }
    }
}
