using Order.Domain.Common;
using Order.Domain.ValueObjects;

namespace Order.Domain.Entities
{
    public class AppOrder : BaseAuditableEntity
    {
        public Login Login { get; set; }
        public TotalPrice TotalPrice { get; set; }

        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public Email Email { get; set; }
        public AddressLine AddressLine { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public ZipCode ZipCode { get; set; }

        public CardName CardName { get; set; }
        public CardNumber CardNumber { get; set; }
        public Expiration Expiration { get; set; }
        public CVV CVV { get; set; }
        public int PaymentMethod { get; set; }
    }
}
