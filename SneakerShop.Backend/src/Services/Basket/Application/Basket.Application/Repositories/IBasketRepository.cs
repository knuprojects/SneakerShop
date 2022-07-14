using Basket.Domain.Entities;
using System.Threading.Tasks;

namespace Basket.Application.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasketAsync(string login);
        Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket);
        Task DeleteBasketAsync(string login);
    }
}
