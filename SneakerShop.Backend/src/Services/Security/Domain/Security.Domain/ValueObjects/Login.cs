using Security.Domain.Exceptions;

namespace Security.Domain.ValueObjects
{
    public class Login
    {
        public string Value { get; set; }

        public Login(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 20 || value.Length < 8)
                throw new InvalidLoginException(value);

            Value = value;
        }

        public static implicit operator Login(string value) => value is null ? null : new Login(value);

        public static implicit operator string(Login value) => value?.Value;

        public override string ToString() => Value;
    }
}
