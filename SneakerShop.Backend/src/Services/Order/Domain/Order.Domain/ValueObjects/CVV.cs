using Order.Domain.Exceptions;

namespace Order.Domain.ValueObjects
{
    public class CVV
    {
        public string Value { get; set; }

        public CVV(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidCvvException(value);

            Value = value;
        }

        public static implicit operator CVV(string value) => value is null ? null : new CVV(value);

        public static implicit operator string(CVV value) => value.Value;

        public override string ToString() => Value;
    }
}
