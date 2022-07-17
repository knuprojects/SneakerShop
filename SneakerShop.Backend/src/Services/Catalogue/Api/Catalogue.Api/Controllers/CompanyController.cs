using Catalogue.Application.Abstraction;
using Catalogue.Application.Commands.Companies.CreateCompany;
using Catalogue.Application.Commands.Companies.DeleteCompany;
using Catalogue.Application.Commands.Companies.UpdateCompany;
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

        private readonly ICommandHandler<CreateCompanyCommand> _commandCreateCompanyHandler;
        private readonly ICommandHandler<UpdateCompanyCommand> _commandUpdateCompanyHandler;
        private readonly ICommandHandler<DeleteCompanyCommand> _commandDeleteCompanyHandler;

        public CompanyController(IQueryHandler<GetCompanies, DataServiceMessage> queryCompaniesHandler,
            IQueryHandler<GetCompaniesById, DataServiceMessage> queryCompanyByIdHandler,
            IQueryHandler<GetCompaniesByName, DataServiceMessage> queryCompanyByNameHandler,
            ICommandHandler<CreateCompanyCommand> commandCreateCompanyHandler,
            ICommandHandler<UpdateCompanyCommand> commandUpdateCompanyHandler,
            ICommandHandler<DeleteCompanyCommand> commandDeleteCompanyHandler
            )
        {
            _queryCompaniesHandler = queryCompaniesHandler;
            _queryCompanyByIdHandler = queryCompanyByIdHandler;
            _queryCompanyByNameHandler = queryCompanyByNameHandler;
            _commandCreateCompanyHandler = commandCreateCompanyHandler;
            _commandUpdateCompanyHandler = commandUpdateCompanyHandler;
            _commandDeleteCompanyHandler = commandDeleteCompanyHandler;
    }

        #region GetMethod
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
        #endregion

        #region Post, Put, Delete Method
        [HttpPost(Routes.CreateCompany)]
        public async Task<ActionResult> CreateCompany(CreateCompanyCommand command)
        {
            await _commandCreateCompanyHandler.HandleAsync(command);
            return Ok();
        }

        [HttpPut(Routes.UpdateCompany)]
        public async Task<ActionResult> UpdateCompany(UpdateCompanyCommand command)
        {
            await _commandUpdateCompanyHandler.HandleAsync(command);
            return Ok();
        }

        [HttpDelete(Routes.DeleteCompany)]
        public async Task<ActionResult> DeleteCompany(DeleteCompanyCommand command)
        {
            await _commandDeleteCompanyHandler.HandleAsync(command);
            return Ok();
        }
        #endregion
    }
}
