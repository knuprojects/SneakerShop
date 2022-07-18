using Catalogue.Application.Abstraction;

namespace Catalogue.Application.Commands.Category.CreateCategory
{
    public class CreateCategoryCommand : ICommand
    {
        public string Name { get; set; }
        public bool? Deleted { get; set; }
        public int CompanyId { get; set; }
    }
}
