using Basket.Domain.Exceptions;

namespace Basket.Domain.ValueObjects
{
    public class Quantity
    {
        public int Value { get; }

        public Quantity(int value)
        {
            if (value <= 0 || value >= 10 || value.Equals(null))
                throw new InvalidQuantityException(value);

            Value = value;
        }
        public static implicit operator int(Quantity value) => value.Value;

        public static implicit operator Quantity(int value) => new Quantity(value);
    }
}
