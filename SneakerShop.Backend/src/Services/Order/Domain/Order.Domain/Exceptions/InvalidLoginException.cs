namespace Order.Domain.Exceptions
{
    public sealed class InvalidLoginException : CustomException
    {
        public string Value { get; }

        public InvalidLoginException(string value) : base($"Login: {value} is invalid.")
        {
            Value = value;
        }
    }
}
