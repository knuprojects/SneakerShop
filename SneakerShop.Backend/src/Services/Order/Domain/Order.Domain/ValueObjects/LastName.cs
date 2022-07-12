using Order.Domain.Exceptions;

namespace Order.Domain.ValueObjects
{
    public class LastName
    {
        public string Value { get; set; }

        public LastName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidLastNameException(value);

            Value = value;
        }

        public static implicit operator LastName(string value) => value is null ? null : new LastName(value);

        public static implicit operator string(LastName value) => value?.Value;

        public override string ToString() => Value;
    }
}
