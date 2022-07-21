using System;

namespace Catalogue.Infrastructure.Exceptions
{
    public class InvalidColourException : CustomException
    {
        public string Colour { get; set; }
        public InvalidColourException(string colour) : base($"Colour: {colour} is invalid!")
        {
            Colour = colour;
        }
    }
}
