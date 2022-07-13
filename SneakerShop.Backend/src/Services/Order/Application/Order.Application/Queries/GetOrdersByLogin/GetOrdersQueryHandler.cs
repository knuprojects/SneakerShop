using Order.Application.Abstraction;
using Order.Application.Dto;
using Order.Application.MiddleTier.Contracts;
using Order.Application.Queries.GetOrdersByName;
using System.Threading.Tasks;

namespace Order.Application.Queries.GetOrdersByLogin
{
    public class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, DataServiceMessage>
    {
        private readonly IOrderView _orderView;

        public GetOrdersQueryHandler(IOrderView orderView)
        {
            _orderView = orderView;
        }

        public async Task<DataServiceMessage> HandleAsync(GetOrdersQuery query)
        {
            return await _orderView.GetOrderByLoginAsync(query.Login);
        }
    }
}
