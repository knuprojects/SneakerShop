using Order.Application.Dto;
using System.Threading.Tasks;

namespace Order.Application.MiddleTier.Contracts
{
    public interface IOrderView
    {
        Task<DataServiceMessage> GetOrderByLoginAsync(string login);
    }
}
