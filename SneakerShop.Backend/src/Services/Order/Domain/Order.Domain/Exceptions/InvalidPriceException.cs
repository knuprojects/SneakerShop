namespace Order.Domain.Exceptions
{
    public sealed class InvalidPriceException : CustomException
    {
        public decimal Value { get; }

        public InvalidPriceException(decimal value) : base($"Total price: {value} is invalid.")
        {
            Value = value;
        }
    }
}
