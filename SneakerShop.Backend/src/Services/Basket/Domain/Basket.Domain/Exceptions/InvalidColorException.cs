namespace Basket.Domain.Exceptions
{
    public sealed class InvalidColorException : CustomException
    {
        public string Value { get; }
        public InvalidColorException(string value) : base($"Color: {value} is invalid!")
        {
            Value = value;
        }
    }
}
