using Order.Domain.Exceptions;

namespace Order.Domain.ValueObjects
{
    public class Country
    {
        public string Value { get; set; }

        public Country(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidCountryException(value);

            Value = value;
        }

        public static implicit operator Country(string value) => value is null ? null : new Country(value);

        public static implicit operator string(Country country) => country.Value;

        public override string ToString() => Value;
    }
}
