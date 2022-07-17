using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Dto;
using Catalogue.Domain.Entities;
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
            var company = new Company
            {
                Name = createCompanyDto.Name,
                Deleted = createCompanyDto.Deleted
            };

            await _catalogueContext.Company.AddAsync(company);
            await _catalogueContext.SaveChangesAsync();

            var data = new DataServiceMessage(true, GoodResponse.AddedSuccessfully, company);
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

            var newCompany = new Company
            {
                CompanyId = updateCompanyDto.CompanyId,
                Name = updateCompanyDto.Name,
                Deleted = updateCompanyDto.Deleted,
            };
            _catalogueContext.Company.Update(newCompany);
            await _catalogueContext.SaveChangesAsync();

            var result = new DataServiceMessage(true, GoodResponse.UpdatedSuccessfully, newCompany);
            return result;
        }
    }
}
