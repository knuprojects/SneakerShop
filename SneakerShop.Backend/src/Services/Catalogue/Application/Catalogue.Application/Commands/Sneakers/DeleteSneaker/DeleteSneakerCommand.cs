using Catalogue.Application.Abstraction;

namespace Catalogue.Application.Commands.Sneakers.DeleteSneaker
{
    public class DeleteSneakerCommand : ICommand
    {
        public int SneakerId { get; set; }
        public bool? Deleted { get; set; }
    }
}
