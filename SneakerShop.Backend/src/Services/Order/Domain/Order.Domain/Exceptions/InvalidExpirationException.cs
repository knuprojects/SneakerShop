namespace Order.Domain.Exceptions
{
    public sealed class InvalidExpirationException : CustomException
    {
        public string Value { get; }

        public InvalidExpirationException(string value) : base($"Expiration: {value} is invalid.")
        {
            Value = value;
        }
    }
}
