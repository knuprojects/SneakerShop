using Basket.Domain.Exceptions;

namespace Basket.Domain.ValueObjects
{
    public class Price
    {
        public decimal Value { get; }

        public Price(decimal value)
        {
            if (value <= 0 || value.Equals(null))
                throw new InvalidPriceException(value);

            Value = value;
        }
        public static implicit operator decimal(Price value) => value.Value;

        public static implicit operator Price(decimal value) => new Price(value);
    }

}
