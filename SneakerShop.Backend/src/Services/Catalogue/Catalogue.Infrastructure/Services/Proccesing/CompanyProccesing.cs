using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Dto;
using Catalogue.Application.Mapper;
using Catalogue.Domain.Exceptions;
using Catalogue.Infrastructure.Dal;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static Catalogue.Domain.Constants.ResponseMessages;

namespace Catalogue.Infrastructure.Services.Proccesing
{
    public class CompanyProccesing : ICompanyProccesing
    {
        private readonly CatalogueContext _catalogueContext;
        public CompanyProccesing(CatalogueContext catalogueContext)
        {
            _catalogueContext = catalogueContext;
        }

        public async Task<DataServiceMessage> CreateCompanyAsync(CreateCompanyDto createCompanyDto)
        {
            var mapper = Mapping.CreateCompanyDtoToCompany(createCompanyDto);

            await _catalogueContext.Company.AddAsync(mapper);
            await _catalogueContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.AddedSuccessfully, mapper);
            return data;
        }

        public async Task<DataServiceMessage> DeleteCompanyAsync(DeleteCompanyDto deleteCompanyDto)
        {
            var company = await _catalogueContext.Company.FirstOrDefaultAsync(x => x.CompanyId == deleteCompanyDto.CompanyId);

            if (company == null)
                throw new InvalidCompanyException(deleteCompanyDto.CompanyId);

            _catalogueContext.Company.Remove(company);
            await _catalogueContext.SaveChangesAsync();

            var result = new DataServiceMessage(true, GoodResponse.DeletedSuccessfully, company);
            return result;
        }

        public async Task<DataServiceMessage> UpdateCompanyAsync(UpDateCompanyDto updateCompanyDto)
        {
            var company = await _catalogueContext.Company.AsNoTracking().FirstOrDefaultAsync(x => x.CompanyId == updateCompanyDto.CompanyId);

            if (company == null)
                throw new InvalidCompanyException(updateCompanyDto.CompanyId);

            var mapper = Mapping.UpdateCompanyDtoToCompany(updateCompanyDto);

            _catalogueContext.Company.Update(mapper);
            await _catalogueContext.SaveChangesAsync();

            var result = new DataServiceMessage(true, GoodResponse.UpdatedSuccessfully, mapper);
            return result;
        }
    }
}
