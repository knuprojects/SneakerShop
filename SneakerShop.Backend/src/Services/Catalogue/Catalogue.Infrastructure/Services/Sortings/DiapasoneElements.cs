using Catalogue.Domain.Entities;
using System.Collections.Generic;

namespace Catalogue.Infrastructure.Services.Sortings
{
    public interface ISortByFilters<T> where T : class
    {
        List<T> GetDiapasonByFilter(List<T> list, decimal minValue, decimal maxValue);
        List<T> Swap(List<T> list);
    };

    public class SortByFilters<T> : ISortByFilters<Sneaker>
    {
        public List<Sneaker> GetDiapasonByFilter(List<Sneaker> list, decimal minValue, decimal maxValue)
        {
            List<Sneaker> result = new List<Sneaker>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Price >= minValue && list[i].Price <= maxValue)
                {
                    result.Add(list[i]);
                }
            }
            return result;
        }

        public List<Sneaker> Swap(List<Sneaker> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    if (list[j].Price > list[j + 1].Price)
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
            return list;
        }
    }
}
