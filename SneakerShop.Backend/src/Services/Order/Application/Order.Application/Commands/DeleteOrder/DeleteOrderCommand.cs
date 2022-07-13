using Order.Application.Abstraction;

namespace Order.Application.Commands.DeleteOrder
{
    public class DeleteOrderCommand : ICommand
    {
        public int OrderId { get; set; }
    }
}
