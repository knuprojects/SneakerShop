using Catalogue.Application.Abstraction;

namespace Catalogue.Application.Commands.Sneakers.CreateSneaker
{
    public class CreateSneakerCommand : ICommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Size { get; set; }
        public string Colour { get; set; }
        public string PhotoUrl { get; set; }
        public bool? Deleted { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
    }
}
