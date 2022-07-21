using System;

namespace Catalogue.Infrastructure.Exceptions
{
    public class InvalidCompanyException : CustomException
    {
        public int CompanyId { get; set; }
        public InvalidCompanyException(int id) : base($"Company: {id} is invalid!")
        {
            CompanyId = id;
        }
    }
}
