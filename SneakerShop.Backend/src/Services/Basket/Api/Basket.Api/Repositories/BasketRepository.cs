using Basket.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Basket.Api.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            if (redisCache.Equals(null))
                throw new ArgumentNullException(nameof(redisCache));
            _redisCache = redisCache;
        }

        public async Task DeleteBasketAsync(string login)
        {
            await _redisCache.RemoveAsync(login);
        }

        public async Task<ShoppingCart> GetBasketAsync(string login)
        {
            var basket = await _redisCache.GetStringAsync(login);

            if (String.IsNullOrEmpty(basket))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket)
        {
            await _redisCache.SetStringAsync(basket.Login, JsonConvert.SerializeObject(basket));

            return await GetBasketAsync(basket.Login);
        }
    }
}
