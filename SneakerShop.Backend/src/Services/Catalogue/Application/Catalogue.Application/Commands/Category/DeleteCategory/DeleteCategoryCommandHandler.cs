using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Mapper;
using System.Threading.Tasks;

namespace Catalogue.Application.Commands.Category.DeleteCategory
{
    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryProccesing _categoryProccesing;
        public DeleteCategoryCommandHandler(ICategoryProccesing categoryProccesing)
        {
            _categoryProccesing = categoryProccesing;
        }

        public async Task HandleAsync(DeleteCategoryCommand command)
        {
            var mapper = Mapping.DeleteCommandCategory(command);
            await _categoryProccesing.DeleteCategoryAsync(mapper);
        }
    }
}
