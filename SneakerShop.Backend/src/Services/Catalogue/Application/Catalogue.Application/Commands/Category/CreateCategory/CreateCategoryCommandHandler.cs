using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Mapper;
using System.Threading.Tasks;

namespace Catalogue.Application.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
    {
        private readonly ICategoryProccesing _categoryProccesing;
        public CreateCategoryCommandHandler(ICategoryProccesing categoryProccesing)
        {
            _categoryProccesing = categoryProccesing;
        }

        public async Task HandleAsync(CreateCategoryCommand command)
        {
            var mapper = Mapping.CreateCommandCategory(command);
            await _categoryProccesing.CreateCategoryAsync(mapper);
        }
    }
}
