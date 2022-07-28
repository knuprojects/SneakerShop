using Catalogue.Domain.Entities;
using System.Collections.Generic;

namespace Catalogue.Infrastructure.Services.Sortings
{
    public static class DiapasoneElements
    {
        public static List<Sneaker> GetDiapasoneSnikers(List<Sneaker> sneakers, decimal minPrice, decimal maxPrice)
        {
            List<Sneaker> result = new List<Sneaker>();
            for (int i = 0; i < sneakers.Count; i++)
            {
                if (sneakers[i].Price >= minPrice && sneakers[i].Price <= maxPrice)
                {
                    result.Add(sneakers[i]);
                }
            }
            return result;
        }

    }
}
