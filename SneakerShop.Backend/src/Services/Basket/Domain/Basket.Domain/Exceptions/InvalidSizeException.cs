namespace Basket.Domain.Exceptions
{
    public sealed class InvalidSizeException : CustomException
    {
        public double Value { get; }
        public InvalidSizeException(double value) : base($"Size: {value} is invalid!")
        {
            Value = value;
        }
    }
}
