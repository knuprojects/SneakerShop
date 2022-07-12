using Order.Domain.Const;
using Order.Domain.Exceptions;

namespace Order.Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; set; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidEmailException(value);

            if (value.Length > 100)
                throw new InvalidEmailException(value);

            value = value.ToLowerInvariant();
            if (!Useful.EmailTemplate.IsMatch(value))
                throw new InvalidEmailException(value);

            Value = value;
        }

        public static implicit operator string(Email value) => value.Value;

        public static implicit operator Email(string value) => new Email(value);

        public override string ToString() => Value;
    }
}
