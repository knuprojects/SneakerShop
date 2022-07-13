using Order.Application.Dto;
using System.Threading.Tasks;

namespace Order.Application.MiddleTier.Contracts
{
    public interface IOrderProccesing
    {
        Task<DataServiceMessage> UpdateOrderAsync(OrderDto dto);
        Task<DataServiceMessage> DeleteOrderAsync(int orderId);
    }
}
