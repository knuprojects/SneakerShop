using Security.Domain.Exceptions;

namespace Security.Domain.ValueObjects
{
    public class Token
    {
        public string Value { get; }

        public Token(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 500)
                throw new InvalidTokenException(value);

            Value = value;
        }

        public static implicit operator Token(string value) => new Token(value);

        public static implicit operator string(Token value) => value.Value;

        public override string ToString() => Value;
    }
}
