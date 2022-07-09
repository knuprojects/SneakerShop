using System;

namespace Security.Application.Exceptions
{
    public class CustomException : Exception
    {
        protected CustomException(string message) : base(message)
        {
        }
    }
}
