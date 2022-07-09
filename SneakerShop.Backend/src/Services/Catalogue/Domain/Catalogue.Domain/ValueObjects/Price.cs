using Catalogue.Domain.Exceptions;

namespace Catalogue.Domain.ValueObjects
{
    public class Price
    {
        public decimal Value { get; set; }
        public Price(decimal value)
        {
            if (value <= 0 || value.Equals(null))
                throw new InvalidPriceException(value);
        }

        public static implicit operator decimal(Price value) => value.Value;

        public static implicit operator Price(decimal value) => new Price(value);
    }
}
