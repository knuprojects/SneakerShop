namespace Order.Domain.Exceptions
{
    public sealed class InvalidCountryException : CustomException
    {
        public string Value { get; }

        public InvalidCountryException(string value) : base($"Country: {value} is invalid.")
        {
            Value = value;
        }
    }
}
