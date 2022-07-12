using Order.Domain.Exceptions;

namespace Order.Domain.ValueObjects
{
    public class ZipCode
    {
        public string Value { get; set; }

        public ZipCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidZipCodeException(value);

            Value = value;
        }

        public static implicit operator ZipCode(string value) => value is null ? null : new ZipCode(value);

        public static implicit operator string(ZipCode value) => value.Value;

        public override string ToString() => Value;
    }
}
