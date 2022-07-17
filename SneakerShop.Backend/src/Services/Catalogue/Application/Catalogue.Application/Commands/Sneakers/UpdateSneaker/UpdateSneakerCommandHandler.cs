using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Mapper;
using System.Threading.Tasks;

namespace Catalogue.Application.Commands.Sneakers.UpdateSneaker
{
    public class UpdateSneakerCommandHandler : ICommandHandler<UpdateSneakerCommand>
    {
        private readonly ISneakerProccesing _sneakerProccesing;
        public UpdateSneakerCommandHandler(ISneakerProccesing sneakerProccesing)
        {
            _sneakerProccesing = sneakerProccesing;
        }
        public async Task HandleAsync(UpdateSneakerCommand command)
        {
            var mapper = Mapping.UpdateCommandSneaker(command);
            await _sneakerProccesing.UpdateSneakerAsync(mapper);
        }
    }
}
