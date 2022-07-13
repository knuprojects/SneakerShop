using Microsoft.AspNetCore.Mvc;
using Order.Application.Abstraction;
using Order.Application.Commands.DeleteOrder;
using Order.Application.Commands.UpdateOrder;
using Order.Application.Dto;
using Order.Application.Queries.GetOrdersByName;
using Order.Domain.Const;
using System.Threading.Tasks;

namespace Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly ICommandHandler<UpdateOrderCommand> _updateOrderHandler;
        private readonly ICommandHandler<DeleteOrderCommand> _deleteOrderHandler;
        private readonly IQueryHandler<GetOrdersQuery, DataServiceMessage> _getOrdersQueryHandler;

        public OrderController(
            ICommandHandler<UpdateOrderCommand> updateOrderHandler,
            ICommandHandler<DeleteOrderCommand> deleteOrderHandler,
            IQueryHandler<GetOrdersQuery, DataServiceMessage> getOrdersQueryHandler)
        {
            _updateOrderHandler = updateOrderHandler;
            _deleteOrderHandler = deleteOrderHandler;
            _getOrdersQueryHandler = getOrdersQueryHandler;
        }

        [HttpGet(Routes.GetOrdersByLogin)]
        public async Task<ActionResult> GetOrders([FromQuery] GetOrdersQuery query)
        {
            var result = await _getOrdersQueryHandler.HandleAsync(query);
            return Ok(result);
        }

        [HttpPost(Routes.UpdateOrder)]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            await _updateOrderHandler.HandleAsync(command);
            return Ok();
        }

        [HttpDelete(Routes.DeleteOrder)]
        public async Task<ActionResult> DeleteOrder([FromBody] DeleteOrderCommand command)
        {
            await _deleteOrderHandler.HandleAsync(command);
            return Ok();
        }
    }
}
