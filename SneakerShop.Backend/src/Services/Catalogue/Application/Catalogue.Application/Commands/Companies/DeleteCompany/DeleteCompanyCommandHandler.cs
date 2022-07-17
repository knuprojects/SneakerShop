using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Mapper;
using System.Threading.Tasks;

namespace Catalogue.Application.Commands.Companies.DeleteCompany
{
    public class DeleteCompanyCommandHandler : ICommandHandler<DeleteCompanyCommand>
    {
        private readonly ICompanyProccesing _companyProccesing;
        public DeleteCompanyCommandHandler(ICompanyProccesing companyProccesing)
        {
            _companyProccesing = companyProccesing;
        }
        public async Task HandleAsync(DeleteCompanyCommand command)
        {
            var mapper = Mapping.DeleteCommandCompany(command);
            await _companyProccesing.DeleteCompanyAsync(mapper);
        }
    }
}
