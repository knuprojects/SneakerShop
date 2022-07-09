namespace Security.Domain.Exceptions
{
    public sealed class InvalidPasswordException : CustomException
    {
        public string Value { get; }

        public InvalidPasswordException(string value) : base($"Password: {value} is invalid.")
        {
            Value = value;
        }
    }
}
