using Catalogue.Application.Abstraction;

namespace Catalogue.Application.Commands.Companies.CreateCompany
{
    public class CreateCompanyCommand : ICommand
    {
        public string Name { get; set; }
        public bool? Deleted { get; set; }
    }
}
