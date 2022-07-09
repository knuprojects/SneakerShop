using System;

namespace Catalogue.Domain.Exceptions
{
    public class InvalidSizeException : Exception
    {
        public double Size { get; set; }
        public InvalidSizeException(double size) : base($"Size: {size} is invalid!")
        {
            Size = size;
        }
    }
}
