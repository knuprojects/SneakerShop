using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Mapper;
using System.Threading.Tasks;

namespace Catalogue.Application.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryProccesing _categoryProccesing;
        public UpdateCategoryCommandHandler(ICategoryProccesing categoryProccesing)
        {
            _categoryProccesing = categoryProccesing;
        }

        public async Task HandleAsync(UpdateCategoryCommand command)
        {
            var mapper = Mapping.UpdateCommandCategory(command);
            await _categoryProccesing.UpdateCategoryAsync(mapper);
        }
    }
}
