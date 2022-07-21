using System;

namespace Catalogue.Infrastructure.Exceptions
{
    public class InvalidCategoryException : CustomException
    {
        public int CategoryId { get; set; }
        public InvalidCategoryException(int id) : base($"Category: {id} is invalid!")
        {
            CategoryId = id;
        }
    }
}
