using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Infrastructure.Exceptions
{
    public class CustomException : Exception
    {
        protected CustomException(string message) : base(message)
        {
        }
    }
}
