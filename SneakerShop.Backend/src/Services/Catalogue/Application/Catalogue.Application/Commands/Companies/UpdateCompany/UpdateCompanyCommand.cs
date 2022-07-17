using Catalogue.Application.Abstraction;

namespace Catalogue.Application.Commands.Companies.UpdateCompany
{
    public class UpdateCompanyCommand : ICommand
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public bool? Deleted { get; set; }
    }
}
