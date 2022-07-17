using System;

namespace Catalogue.Domain.Exceptions
{
    public class InvalidSneakerException : Exception
    {
        public int SneakerId { get; set; }
        public InvalidSneakerException(int id) : base($"Sneaker: {id} is invalid!")
        {
            SneakerId = id;
        }
    }
}
