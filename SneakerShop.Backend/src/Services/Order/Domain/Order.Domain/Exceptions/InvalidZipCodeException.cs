namespace Order.Domain.Exceptions
{
    public sealed class InvalidZipCodeException : CustomException
    {
        public string Value { get; }

        public InvalidZipCodeException(string value) : base($"Zip Code: {value} is invalid.")
        {
            Value = value;
        }
    }
}
