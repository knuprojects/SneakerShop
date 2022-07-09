using Catalogue.Domain.Common;
using Catalogue.Domain.ValueObjects;
using System.Collections.Generic;

namespace Catalogue.Domain.Entities
{
    public class Category : IBaseEntity
    {
        public Category()
        {
            Sneakers = new HashSet<Sneaker>();
        }

        public int CategoryId { get; set; }
        public Name Name { get; set; }
        public bool? Deleted { get; set; }

        public IReadOnlyCollection<Sneaker> Sneakers { get; set; }
    }
}
