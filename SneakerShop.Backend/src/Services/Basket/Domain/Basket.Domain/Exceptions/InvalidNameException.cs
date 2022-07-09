using System;

namespace Basket.Domain.Exceptions
{
    public sealed class InvalidNameException : Exception
    {
        public string Value { get; }

        public InvalidNameException(string value) : base($"Name: {value} is invalid!")
        {
            Value = value;
        }
    }
}
