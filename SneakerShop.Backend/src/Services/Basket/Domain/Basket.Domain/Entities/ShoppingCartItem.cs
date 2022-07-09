using Basket.Domain.ValueObjects;

namespace Basket.Domain.Entities
{
    public class ShoppingCartItem
    {
        public Quantity Quantity { get; set; }
        public Name Name { get; set; }
        public Price Price { get; set; }
        public Size Size { get; set; }
        public Colour Colour { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
    }
}
