﻿using Basket.Domain.Entities;
using System.Threading.Tasks;

namespace Basket.Api.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasketAsync(string logit);
        Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket);
        Task DeleteBasketAsync(string login);
    }
}
