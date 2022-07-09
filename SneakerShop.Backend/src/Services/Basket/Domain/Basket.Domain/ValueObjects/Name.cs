using Basket.Domain.Exceptions;

namespace Basket.Domain.ValueObjects
{
    public class Name
    {
        public string Value { get; }

        public Name(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidNameException(value);
            if (value.Length > 100)
                throw new InvalidNameException(value);

            Value = value;
        }

        public static implicit operator string(Name value) => value.Value;

        public static implicit operator Name(string value) => new Name(value);

        public override string ToString() => Value;
    }
}
