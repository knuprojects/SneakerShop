using Order.Domain.Exceptions;

namespace Order.Domain.ValueObjects
{
    public class AddressLine
    {
        public string Value { get; set; }

        public AddressLine(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidAddressLineException(value);

            Value = value;
        }

        public static implicit operator AddressLine(string value) => value is null ? null : new AddressLine(value);

        public static implicit operator string(AddressLine addressLine) => addressLine.Value;

        public override string ToString() => Value;
    }
}
