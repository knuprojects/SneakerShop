using Basket.Domain.ValueObjects;

namespace Basket.Domain.Entities
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Size { get; set; }
        public string Colour { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
    }
}
