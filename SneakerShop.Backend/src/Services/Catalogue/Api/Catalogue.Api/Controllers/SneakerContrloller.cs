using Catalogue.Application.Abstraction;
using Catalogue.Application.Dto;
using Catalogue.Application.Queries.Sneakers.GetAll;
using Catalogue.Application.Queries.Sneakers.GetById;
using Catalogue.Application.Queries.Sneakers.GetByName;
using Catalogue.Domain.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Catalogue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SneakerContrloller : ControllerBase
    {
        private readonly IQueryHandler<GetSneakers, DataServiceMessage> _querySneakersHandler;
        private readonly IQueryHandler<GetSneakersById, DataServiceMessage> _querySneakersByIdHandler;
        private readonly IQueryHandler<GetSneakersByName, DataServiceMessage> _querySneakersByNameHandler;

        public SneakerContrloller(IQueryHandler<GetSneakers, DataServiceMessage> querySneakersHandler,
            IQueryHandler<GetSneakersById, DataServiceMessage> querySneakersByIdHandler,
            IQueryHandler<GetSneakersByName, DataServiceMessage> querySneakersByNameHandler
            )
        {
            _querySneakersHandler = querySneakersHandler;
            _querySneakersByIdHandler = querySneakersByIdHandler;
            _querySneakersByNameHandler = querySneakersByNameHandler;
        }

        [HttpGet(Routes.GetAllSneakers)]
        public async Task<ActionResult> GetAllSneakers([FromQuery] GetSneakers query)
        {
            var result = await _querySneakersHandler.HandleAsync(query);
            return Ok(result);
        }

        [HttpGet(Routes.GetAllSneakersById)]
        public async Task<ActionResult> GetSneakersById([FromQuery] GetSneakersById query)
        {
            var result = await _querySneakersByIdHandler.HandleAsync(query);
            return Ok(result);
        }

        [HttpGet(Routes.GetAllSneakersByName)]
        public async Task<ActionResult> GetSneakersByName([FromQuery] GetSneakersByName query)
        {
            var result = await _querySneakersByNameHandler.HandleAsync(query);
            return Ok(result);
        }
    }
}
