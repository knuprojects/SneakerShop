using Order.Domain.Exceptions;

namespace Order.Domain.ValueObjects
{
    public class TotalPrice
    {
        public decimal Value { get; }

        public TotalPrice(decimal value)
        {
            if (value <= 0 || value.Equals(null))
                throw new InvalidPriceException(value);

            Value = value;
        }
        public static implicit operator decimal(TotalPrice value) => value.Value;

        public static implicit operator TotalPrice(decimal value) => new TotalPrice(value);
    }
}
