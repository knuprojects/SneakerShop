using Basket.Domain.Common;
using System.Collections.Generic;

namespace Basket.Domain.Entities
{
    public class ShoppingCart : BaseAuditableEntity
    {
        public string Login { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public ShoppingCart()
        {
        }

        public ShoppingCart(string login)
        {
            Login = login;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price * item.Quantity;
                }
                return totalprice;
            }
        }
    }
}
