using Security.Domain.Exceptions;

namespace Security.Domain.ValueObjects
{
    public class Password
    {
        public string Value { get; set; }

        public Password(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length > 500 || value.Length < 8)
                throw new InvalidPasswordException(value);

            Value = value;
        }

        public static implicit operator string(Password value) => value.Value;

        public static implicit operator Password(string value) => new Password(value);

        public override string ToString() => Value;
    }
}
