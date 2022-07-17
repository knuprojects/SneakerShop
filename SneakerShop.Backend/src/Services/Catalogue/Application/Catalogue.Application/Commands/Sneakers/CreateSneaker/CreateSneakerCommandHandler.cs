using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Mapper;
using System.Threading.Tasks;

namespace Catalogue.Application.Commands.Sneakers.CreateSneaker
{
    public class CreateSneakerCommandHandler : ICommandHandler<CreateSneakerCommand>
    {
        private readonly ISneakerProccesing _sneakerProccesing;
        public CreateSneakerCommandHandler(ISneakerProccesing sneakerProccesing)
        {
            _sneakerProccesing = sneakerProccesing;
        }
        public async Task HandleAsync(CreateSneakerCommand command)
        {
            var mapper = Mapping.CreateCommandSneaker(command);
            await _sneakerProccesing.CreateSneakerAsync(mapper);
        }
    }
}
