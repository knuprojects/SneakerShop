namespace Order.Domain.Exceptions
{
    public sealed class InvalidLastNameException : CustomException
    {
        public string Value { get; }

        public InvalidLastNameException(string value) : base($"Last name: {value} is invalid.")
        {
            Value = value;
        }
    }
}
