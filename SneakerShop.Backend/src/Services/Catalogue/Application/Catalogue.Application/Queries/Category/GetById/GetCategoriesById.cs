using Catalogue.Application.Abstraction;
using Catalogue.Application.Dto;

namespace Catalogue.Application.Queries.Category.GetById
{
    public class GetCategoriesById : IQuery<DataServiceMessage>
    {
        public int CategoryId { get; set; }
    }
}
