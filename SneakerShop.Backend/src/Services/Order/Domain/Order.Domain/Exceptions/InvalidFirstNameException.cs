namespace Order.Domain.Exceptions
{
    public sealed class InvalidFirstNameException : CustomException
    {
        public string Value { get; }

        public InvalidFirstNameException(string value) : base($"First name: {value} is invalid.")
        {
            Value = value;
        }
    }
}
