namespace Basket.Domain.Exceptions
{
    public sealed class InvalidPriceException : CustomException
    {
        decimal Value { get; }
        public InvalidPriceException(decimal value) : base($"Price: {value} is invalid!")
        {
            Value = value;
        }
    }
}
