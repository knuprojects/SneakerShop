using Catalogue.Application.Abstraction;

namespace Catalogue.Application.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommand : ICommand
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool? Deleted { get; set; }
        public int CompanyId { get; set; }
    }
}
