using Catalogue.Application.Abstraction;

namespace Catalogue.Application.Commands.Category.DeleteCategory
{
    public class DeleteCategoryCommand : ICommand
    {
        public int CategoryId { get; set; }
        public bool? Deleted { get; set; }
    }
}
