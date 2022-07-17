using System;

namespace Catalogue.Domain.Exceptions
{
    public class InvalidCategoryException : Exception
    {
        public int CategoryId { get; set; }
        public InvalidCategoryException(int id) : base($"Category: {id} is invalid!")
        {
            CategoryId = id;
        }
    }
}
