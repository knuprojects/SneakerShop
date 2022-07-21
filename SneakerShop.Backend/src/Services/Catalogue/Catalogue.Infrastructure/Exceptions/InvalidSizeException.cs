using System;

namespace Catalogue.Infrastructure.Exceptions
{
    public class InvalidSizeException : CustomException
    {
        public double Size { get; set; }
        public InvalidSizeException(double size) : base($"Size: {size} is invalid!")
        {
            Size = size;
        }
    }
}
