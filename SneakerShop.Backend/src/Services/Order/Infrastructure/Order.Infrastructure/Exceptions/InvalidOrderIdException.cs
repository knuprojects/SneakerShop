namespace Order.Infrastructure.Exceptions
{
    public sealed class InvalidOrderIdException : CustomException
    {
        public int Value { get; }

        public InvalidOrderIdException(int value) : base($"OrderId: {value} is invalid.")
        {
            Value = value;
        }
    }
}
