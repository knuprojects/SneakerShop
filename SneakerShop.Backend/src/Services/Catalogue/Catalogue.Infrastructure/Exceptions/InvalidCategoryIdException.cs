using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Infrastructure.Exceptions
{
    public sealed class InvalidCategoryIdException : CustomException
    {
        public int Value { get; }
        public InvalidCategoryIdException(int value) : base($"Category id: {value} is invalid!")
        {
            Value = value;
        }
    }
}
