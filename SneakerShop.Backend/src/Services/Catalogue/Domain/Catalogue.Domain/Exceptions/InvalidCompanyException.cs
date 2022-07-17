using System;

namespace Catalogue.Domain.Exceptions
{
    public class InvalidCompanyException : Exception
    {
        public int CompanyId { get; set; }
        public InvalidCompanyException(int id) : base($"Company: {id} is invalid!")
        {
            CompanyId = id;
        }
    }
}
