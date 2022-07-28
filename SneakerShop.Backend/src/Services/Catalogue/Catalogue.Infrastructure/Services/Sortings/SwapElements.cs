using Catalogue.Domain.Entities;
using System.Collections.Generic;

namespace Catalogue.Infrastructure.Services.Sortings
{
    public static class SwapElements
    {
        public static List<Sneaker> Swap(List<Sneaker> sneakers)
        {
            for (int i = 0; i < sneakers.Count; i++)
            {
                for (int j = 0; j < sneakers.Count - 1-i; j++)
                {
                    if (sneakers[j].Price > sneakers[j+1].Price)
                    {
                        var temp = sneakers[j];
                        sneakers[j] = sneakers[j+1];
                        sneakers[j+1] = temp;
                    }
                }
            }
            return sneakers;
        }

    }
}
