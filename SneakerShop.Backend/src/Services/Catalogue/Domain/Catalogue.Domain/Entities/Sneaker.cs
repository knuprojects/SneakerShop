using Catalogue.Domain.Common;

namespace Catalogue.Domain.Entities
{
    public class Sneaker : IBaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Size { get; set; }
        public string Colour { get; set; }
        public bool? IsFavourite { get; set; }
        public bool? Deleted { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Company Company { get; set; }
    }
}
