namespace Order.Domain.Exceptions
{
    public sealed class InvalidAddressLineException : CustomException
    {
        public string Value { get; }

        public InvalidAddressLineException(string value) : base($"Adress: {value} is invalid.")
        {
            Value = value;
        }
    }
}
