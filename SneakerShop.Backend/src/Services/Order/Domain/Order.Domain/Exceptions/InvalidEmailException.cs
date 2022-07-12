namespace Order.Domain.Exceptions
{
    public sealed class InvalidEmailException : CustomException
    {
        public string Value { get; }

        public InvalidEmailException(string value) : base($"Email: {value} is invalid.")
        {
            Value = value;
        }
    }
}
