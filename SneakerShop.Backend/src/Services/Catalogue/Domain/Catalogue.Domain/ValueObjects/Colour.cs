using Catalogue.Domain.Exceptions;

namespace Catalogue.Domain.ValueObjects
{
    public class Colour
    {
        public string Value { get; set; }
        public Colour(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidColourException(value);
            if (value.Length > 128 || value.Length < 3)
                throw new InvalidColourException(value);

            Value = value;
        }

        public static implicit operator Colour(string color) => new Colour(color);

        public static implicit operator string(Colour colour) => colour.Value;
        public override string ToString() => Value;
    }
}
