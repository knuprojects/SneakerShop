using System;

namespace Catalogue.Domain.Exceptions
{
    public class InvalidColourException : Exception
    {
        public string Colour { get; set; }
        public InvalidColourException(string colour) : base($"Colour: {colour} is invalid!")
        {
            Colour = colour;
        }
    }
}
