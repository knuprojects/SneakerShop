namespace Order.Domain.Exceptions
{
    public sealed class InvalidStateException : CustomException
    {
        public string Value { get; }

        public InvalidStateException(string value) : base($"State: {value} is invalid.")
        {
            Value = value;
        }
    }
}
