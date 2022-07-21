using System;

namespace Catalogue.Infrastructure.Exceptions
{
    public class InvalidNameException : CustomException
    {
        public string Name { get; set; }
        public InvalidNameException(string name) : base($"Name: {name} is invalid!")
        {
            Name = name;
        }
    }
}
