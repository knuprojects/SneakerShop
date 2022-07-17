using Catalogue.Application.Abstraction;
using Catalogue.Application.Commands.Sneakers.CreateSneaker;
using Catalogue.Application.Commands.Sneakers.DeleteSneaker;
using Catalogue.Application.Commands.Sneakers.UpdateSneaker;
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

        private readonly ICommandHandler<CreateSneakerCommand> _commandCreateSneakerHandler;
        private readonly ICommandHandler<UpdateSneakerCommand> _commandUpdateSneakerHandler;
        private readonly ICommandHandler<DeleteSneakerCommand> _commandDeleteSneakerHandler;

        public SneakerContrloller(IQueryHandler<GetSneakers, DataServiceMessage> querySneakersHandler,
            IQueryHandler<GetSneakersById, DataServiceMessage> querySneakersByIdHandler,
            IQueryHandler<GetSneakersByName, DataServiceMessage> querySneakersByNameHandler,
            ICommandHandler<CreateSneakerCommand> commandCreateSneakerHandler,
            ICommandHandler<UpdateSneakerCommand> commandUpdateSneakerHandler,
            ICommandHandler<DeleteSneakerCommand> commandDeleteSneakerHandler
            )
        {
            _querySneakersHandler = querySneakersHandler;
            _querySneakersByIdHandler = querySneakersByIdHandler;
            _querySneakersByNameHandler = querySneakersByNameHandler;
            _commandCreateSneakerHandler = commandCreateSneakerHandler;
            _commandUpdateSneakerHandler = commandUpdateSneakerHandler;
            _commandDeleteSneakerHandler = commandDeleteSneakerHandler;
        }


        #region Get Method
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
        #endregion

        #region Post, Put, Delete Method
        [HttpPost(Routes.CreateSneaker)]
        public async Task<ActionResult>  CreateSneaker(CreateSneakerCommand createSneakerCommand)
        {
            await _commandCreateSneakerHandler.HandleAsync(createSneakerCommand);
            return Ok();
        }

        [HttpPut(Routes.UpdateSneaker)]
        public async Task<ActionResult> UpdateSneaker(UpdateSneakerCommand updateSneakerCommand)
        {
            await _commandUpdateSneakerHandler.HandleAsync(updateSneakerCommand);
            return Ok();
        }

        [HttpDelete(Routes.DeleteSneaker)]
        public async Task<ActionResult> DeleteSneaker(DeleteSneakerCommand deleteSneakerCommand)
        {
            await _commandDeleteSneakerHandler.HandleAsync(deleteSneakerCommand);
            return Ok();
        }
        #endregion
    }
}
