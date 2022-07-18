using Catalogue.Application.Abstraction;
using Catalogue.Application.Commands.Category.CreateCategory;
using Catalogue.Application.Commands.Category.DeleteCategory;
using Catalogue.Application.Commands.Category.UpdateCategory;
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

        private readonly ICommandHandler<CreateCategoryCommand> _commandCreateCategoryHandler;
        private readonly ICommandHandler<DeleteCategoryCommand> _commandDeleteCategoryHandler;
        private readonly ICommandHandler<UpdateCategoryCommand> _commandUpdateCategoryHandler;



        public CategoryController(IQueryHandler<GetCategories, DataServiceMessage> queryCategoriesHandler,
            IQueryHandler<GetCategoriesById, DataServiceMessage> queryCategoriesByIdHandler,
            IQueryHandler<GetCategoriesByName, DataServiceMessage> queryCategoriesByNameHandler,
            ICommandHandler<CreateCategoryCommand> commandCreateCategoryHandler,
            ICommandHandler<DeleteCategoryCommand> commandDeleteCategoryHandler,
            ICommandHandler<UpdateCategoryCommand> commandUpdateCategoryHandler
            )
        {
            _queryCategoriesHandler = queryCategoriesHandler;
            _queryCategoriesByIdHandler = queryCategoriesByIdHandler;
            _queryCategoriesByNameHandler = queryCategoriesByNameHandler;
            _commandCreateCategoryHandler = commandCreateCategoryHandler;
            _commandDeleteCategoryHandler = commandDeleteCategoryHandler;
            _commandUpdateCategoryHandler = commandUpdateCategoryHandler;
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

        [HttpPost(Routes.CreateCategory)]
        public async Task<ActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _commandCreateCategoryHandler.HandleAsync(command);
            return Ok();
        }

        [HttpPut(Routes.UpdateCategory)]
        public async Task<ActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _commandUpdateCategoryHandler.HandleAsync(command);
            return Ok();
        }

        [HttpDelete(Routes.DeleteCategory)]
        public async Task<ActionResult> DeleteCategory(DeleteCategoryCommand command)
        {
            await _commandDeleteCategoryHandler.HandleAsync(command);
            return Ok();
        }
    }
}
