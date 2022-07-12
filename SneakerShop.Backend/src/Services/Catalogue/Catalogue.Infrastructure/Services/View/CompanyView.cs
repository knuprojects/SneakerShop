using Catalogue.Application.Contracts.View;
using Catalogue.Application.Dto;
using Catalogue.Infrastructure.Dal;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static Catalogue.Domain.Constants.ResponseMessages;

namespace Catalogue.Infrastructure.Services.View
{
    public class CompanyView : ICompanyView
    {
        private readonly CatalogueContext _catalogueContext;
        public CompanyView(CatalogueContext catalogueContext)
        {
            _catalogueContext = catalogueContext;
        }
        public async Task<DataServiceMessage> GetAllCompanies()
        {
            var result = await _catalogueContext.Company.ToListAsync();
            var data = new DataServiceMessage(true, GoodResponse.GetSuccessfully, result);
            return data;
        }

        public async Task<DataServiceMessage> GetCompanyById(int id)
        {
            var result = await _catalogueContext.Company.FirstOrDefaultAsync(x => x.CompanyId == id);
            var data = new DataServiceMessage(true, GoodResponse.GetSuccessfully, result);
            return data;
        }

        public async Task<DataServiceMessage> GetCompanyByName(string name)
        {
            var result = await _catalogueContext.Company.FirstOrDefaultAsync(x => x.Name == name);
            var data = new DataServiceMessage(true, GoodResponse.GetSuccessfully, result);
            return data;
        }
    }
}
