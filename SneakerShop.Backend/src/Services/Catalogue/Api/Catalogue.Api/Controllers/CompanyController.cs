using Catalogue.Application.Abstraction;
using Catalogue.Application.Dto;
using Catalogue.Application.Queries.Companies.GetAll;
using Catalogue.Application.Queries.Companies.GetById;
using Catalogue.Application.Queries.Companies.GetByName;
using Catalogue.Domain.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace Catalogue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IQueryHandler<GetCompanies, DataServiceMessage> _queryCompaniesHandler;
        private readonly IQueryHandler<GetCompaniesById, DataServiceMessage> _queryCompanyByIdHandler;
        private readonly IQueryHandler<GetCompaniesByName, DataServiceMessage> _queryCompanyByNameHandler;

        public CompanyController(IQueryHandler<GetCompanies, DataServiceMessage> queryCompaniesHandler,
            IQueryHandler<GetCompaniesById, DataServiceMessage> queryCompanyByIdHandler,
            IQueryHandler<GetCompaniesByName, DataServiceMessage> queryCompanyByNameHandler
            )
        {
            _queryCompaniesHandler = queryCompaniesHandler;
            _queryCompanyByIdHandler = queryCompanyByIdHandler;
            _queryCompanyByNameHandler = queryCompanyByNameHandler;
        }

        [HttpGet(Routes.GetAllCompanies)]
        public async Task<ActionResult> GetAllCompanies([FromQuery] GetCompanies query)
        {
            var result = await _queryCompaniesHandler.HandleAsync(query);
            return Ok(result);
        }

        [HttpGet(Routes.GetAllCompanyById)]
        public async Task<ActionResult> GetAllCompanyById([FromQuery] GetCompaniesById query)
        {
            var result = await _queryCompanyByIdHandler.HandleAsync(query);
            return Ok(result);
        }

        [HttpGet(Routes.GetAllCompanyByName)]
        public async Task<ActionResult> GetAllCompanyByName([FromQuery] GetCompaniesByName query)
        {
            var result = await _queryCompanyByNameHandler.HandleAsync(query);
            return Ok(result);
        }
    }
}
