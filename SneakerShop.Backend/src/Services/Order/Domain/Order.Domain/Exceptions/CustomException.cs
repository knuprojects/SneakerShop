﻿using System;

namespace Order.Domain.Exceptions
{
    public class CustomException : Exception
    {
        protected CustomException(string message) : base(message)
        {
        }
    }
}
