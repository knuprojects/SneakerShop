using Order.Application.Abstraction;
using Order.Application.MiddleTier.Contracts;
using System.Threading.Tasks;

namespace Order.Application.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand>
    {
        private readonly IOrderProccesing _orderProccesing;

        public DeleteOrderCommandHandler(IOrderProccesing orderProccesing)
        {
            _orderProccesing = orderProccesing;
        }

        public async Task HandleAsync(DeleteOrderCommand command)
        {
            await _orderProccesing.DeleteOrderAsync(command.OrderId);
        }
    }
}
