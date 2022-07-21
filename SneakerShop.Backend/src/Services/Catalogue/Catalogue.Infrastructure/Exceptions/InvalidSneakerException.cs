using System;

namespace Catalogue.Infrastructure.Exceptions
{
    public class InvalidSneakerException : CustomException
    {
        public int SneakerId { get; set; }
        public InvalidSneakerException(int id) : base($"Sneaker: {id} is invalid!")
        {
            SneakerId = id;
        }
    }
}
