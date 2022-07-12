namespace Order.Domain.Exceptions
{
    public sealed class InvalidCvvException : CustomException
    {
        public string Value { get; }

        public InvalidCvvException(string value) : base($"Cvv: {value} is invalid.")
        {
            Value = value;
        }
    }
}
