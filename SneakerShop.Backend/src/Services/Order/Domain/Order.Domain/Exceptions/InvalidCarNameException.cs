namespace Order.Domain.Exceptions
{
    public sealed class InvalidCarNameException : CustomException
    {
        public string Value { get; }

        public InvalidCarNameException(string value) : base($"Card Name: {value} is invalid.")
        {
            Value = value;
        }
    }
}
