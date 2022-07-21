using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Infrastructure.Exceptions
{
    public sealed class InvalidSneakerIdException : CustomException
    {
        public int Value { get; }
        public InvalidSneakerIdException(int value) : base($"Sneaker id: {value} is invalid!")
        {
            Value = value;
        }
    }
}
