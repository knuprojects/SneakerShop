using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Domain.Const
{
    public static class Routes
    {
        public const string GetBasketByLogin = "/basket/{login}";
        public const string PostBasket = "/basket";
        public const string DeleteBasket = "/basket/{login}";
    }
}
