using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Infrastructure.Exceptions
{
    public class InvalidPriceException : CustomException
    {
        public decimal Price { get; set; }
        public InvalidPriceException(decimal price) : base($"Price: {price} is invalid!")
        {
            Price = price;
        }
    }
}
