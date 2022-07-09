namespace Basket.Domain.Exceptions
{
    public sealed class InvalidQuantityException : CustomException
    {
        int Value;
        public InvalidQuantityException(int value) : base($"Quantity: {value} is invalid!")
        {
            Value = value;
        }
    }
}
