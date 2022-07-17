using Catalogue.Domain.Common;
using Catalogue.Domain.ValueObjects;
using System.Collections.Generic;

namespace Catalogue.Domain.Entities
{
    public class Company : IBaseEntity
    {
        public Company()
        {
            Sneakers = new HashSet<Sneaker>();
        }

        public int CompanyId { get; set; }
        public Name Name { get; set; }
        public bool? Deleted { get; set; }

        public IReadOnlyCollection<Sneaker> Sneakers { get; set; }
    }
}
