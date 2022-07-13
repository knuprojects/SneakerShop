using Order.Application.Abstraction;
using Order.Application.Mapper;
using Order.Application.MiddleTier.Contracts;
using System.Threading.Tasks;

namespace Order.Application.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand>
    {
        private readonly IOrderProccesing _orderProccesing;

        public UpdateOrderCommandHandler(IOrderProccesing orderProccesing)
        {
            _orderProccesing = orderProccesing;
        }

        public async Task HandleAsync(UpdateOrderCommand command)
        {
            var mapper = Mapping.UpdateCommandToOrder(command);
            await _orderProccesing.UpdateOrderAsync(mapper);
        }
    }
}
