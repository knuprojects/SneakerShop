using Basket.Domain.Exceptions;

namespace Basket.Domain.ValueObjects
{
    public class Size
    {
        public double Value { get; }
        public Size(double value)
        {
            if (value < 30 || value > 50 || value.Equals(null))
                throw new InvalidSizeException(value);

            Value = value;
        }

        public static implicit operator double(Size value) => value.Value;

        public static implicit operator Size(double value) => new Size(value);
    }
}
