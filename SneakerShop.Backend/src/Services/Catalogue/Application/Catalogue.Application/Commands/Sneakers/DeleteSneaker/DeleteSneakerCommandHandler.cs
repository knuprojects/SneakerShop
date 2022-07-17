using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Mapper;
using System.Threading.Tasks;

namespace Catalogue.Application.Commands.Sneakers.DeleteSneaker
{
    public class DeleteSneakerCommandHandler : ICommandHandler<DeleteSneakerCommand>
    {
        private readonly ISneakerProccesing _sneakerProccesing;
        public DeleteSneakerCommandHandler(ISneakerProccesing sneakerProccesing)
        {
            _sneakerProccesing = sneakerProccesing;
        }
        public async Task HandleAsync(DeleteSneakerCommand command)
        {
            var mapper = Mapping.DeleteCommandSneaker(command);
            await _sneakerProccesing.DeleteSneakerAsync(mapper);
        }
    }
}
