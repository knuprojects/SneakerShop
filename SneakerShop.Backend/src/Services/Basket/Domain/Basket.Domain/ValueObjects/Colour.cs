using Basket.Domain.Exceptions;

namespace Basket.Domain.ValueObjects
{
    public class Colour
    {
        public string Value { get; }

        public Colour(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidColorException("value");
            if (value.Length > 100)
                throw new InvalidColorException("value");

            Value = value;
        }

        public static implicit operator string(Colour value) => value.Value;

        public static implicit operator Colour(string value) => new Colour(value);

        public override string ToString() => Value;
    }
}
