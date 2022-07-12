using Order.Domain.Exceptions;

namespace Order.Domain.ValueObjects
{
    public class FirstName
    {
        public string Value { get; set; }

        public FirstName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidFirstNameException(value);

            Value = value;
        }

        public static implicit operator FirstName(string value) => value is null ? null : new FirstName(value);

        public static implicit operator string(FirstName value) => value?.Value;

        public override string ToString() => Value;
    }
}
