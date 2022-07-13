using Order.Application.Abstraction;
using Order.Application.Dto;

namespace Order.Application.Queries.GetOrdersByName
{
    public class GetOrdersQuery : IQuery<DataServiceMessage>
    {
        public string Login { get; set; }
    }
}
