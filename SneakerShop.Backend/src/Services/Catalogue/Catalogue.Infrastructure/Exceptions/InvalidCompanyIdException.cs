using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Infrastructure.Exceptions
{
    public sealed class InvalidCompanyIdException : CustomException
    {
        public int Value { get; }
        public InvalidCompanyIdException(int value) : base($"Company id: {value} is invalid!")
        {
            Value = value;
        }
    }
}
