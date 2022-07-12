using Order.Domain.Exceptions;

namespace Order.Domain.ValueObjects
{
    public class Expiration
    {
        public string Value { get; }

        public Expiration(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidExpirationException(value);

            Value = value;
        }

        public static implicit operator Expiration(string value) => value is null ? null : new Expiration(value);

        public static implicit operator string(Expiration value) => value.Value;

        public override string ToString() => Value;
    }
}
