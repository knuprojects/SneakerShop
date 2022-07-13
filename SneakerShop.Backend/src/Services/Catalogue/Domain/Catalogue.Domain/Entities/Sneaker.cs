using Catalogue.Domain.Common;
using Catalogue.Domain.ValueObjects;

namespace Catalogue.Domain.Entities
{
    public class Sneaker : IBaseEntity
    {
        public int SneakerId { get; set; }
        public Name Name { get; set; }
        public Price Price { get; set; }
        public Size Size { get; set; }
        public Colour Colour { get; set; }
        public PhotoUrl PhotoUrl { get; set; }
        public bool? IsFavourite { get; set; }
        public bool? Deleted { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Company Company { get; set; }
    }
}
