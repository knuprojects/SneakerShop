using Catalogue.Domain.Common;
using System.Collections.Generic;

namespace Catalogue.Domain.Entities
{
    public class Company : IBaseEntity
    {
        public Company()
        {
            Sneakers = new HashSet<Sneaker>();
            Categories = new HashSet<Category>(); 
        }

        public int CompanyId { get; set; }
        public string Name { get; set; }
        public bool? Deleted { get; set; }
        public int CategoryId { get; set; }

        public IReadOnlyCollection<Sneaker> Sneakers { get; set; }
        public IReadOnlyCollection<Category> Categories { get; set; }
    }
}
