using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Domain.Exceptions
{
    public class InvalidPriceException : Exception
    {
        public decimal Price { get; set; }
        public InvalidPriceException(decimal price) : base($"Price: {price} is invalid!")
        {
            Price = price;
        }
    }
}
