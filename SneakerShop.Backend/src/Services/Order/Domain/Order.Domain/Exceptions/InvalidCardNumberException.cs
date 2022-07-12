namespace Order.Domain.Exceptions
{
    public sealed class InvalidCardNumberException : CustomException
    {
        public string Value { get; }

        public InvalidCardNumberException(string value) : base($"Card Number: {value} is invalid.")
        {
            Value = value;
        }
    }
}
