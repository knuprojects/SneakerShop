using Catalogue.Application.Abstraction;

namespace Catalogue.Application.Commands.Companies.DeleteCompany
{
    public class DeleteCompanyCommand : ICommand
    {
        public int CompanyId { get; set; }
        public bool? Deleted { get; set; }
    }
}
