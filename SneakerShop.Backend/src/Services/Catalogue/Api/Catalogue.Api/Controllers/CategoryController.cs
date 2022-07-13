using Catalogue.Application.Abstraction;
using Catalogue.Application.Dto;
using Catalogue.Application.Queries.Category.GetAll;
using Catalogue.Application.Queries.Category.GetById;
using Catalogue.Application.Queries.Category.GetByName;
using Catalogue.Domain.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Catalogue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IQueryHandler<GetCategories, DataServiceMessage> _queryCategoriesHandler;
        private readonly IQueryHandler<GetCategoriesById, DataServiceMessage> _queryCategoriesByIdHandler;
        private readonly IQueryHandler<GetCategoriesByName, DataServiceMessage> _queryCategoriesByNameHandler;

        public CategoryController(IQueryHandler<GetCategories, DataServiceMessage> queryCategoriesHandler,
            IQueryHandler<GetCategoriesById, DataServiceMessage> queryCategoriesByIdHandler,
            IQueryHandler<GetCategoriesByName, DataServiceMessage> queryCategoriesByNameHandler
            )
        {
            _queryCategoriesHandler = queryCategoriesHandler;
            _queryCategoriesByIdHandler = queryCategoriesByIdHandler;
            _queryCategoriesByNameHandler = queryCategoriesByNameHandler;
        }

        [HttpGet(Routes.GetAllCategories)]
        public async Task<ActionResult> GetAllCategories([FromQuery] GetCategories query)
        {
            var result = await _queryCategoriesHandler.HandleAsync(query);
            return Ok(result);
        }

        [HttpGet(Routes.GetAllCategoriesById)]
        public async Task<ActionResult> GetAllCategoriesById([FromQuery] GetCategoriesById query)
        {
            var result = await _queryCategoriesByIdHandler.HandleAsync(query);
            return Ok(result);
        }

        [HttpGet(Routes.GetAllCategoriesByName)]
        public async Task<ActionResult> GetAllCategoriesByName([FromQuery] GetCategoriesByName query)
        {
            var result = await _queryCategoriesByNameHandler.HandleAsync(query);
            return Ok(result);
        }
    }
}
