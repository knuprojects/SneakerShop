namespace Security.Domain.Exceptions
{
    public sealed class InvalidTokenException : CustomException
    {
        public string Value { get; }

        public InvalidTokenException(string value) : base($"Token: {value} ins invalid.")
        {
            Value = value;
        }
    }
}
