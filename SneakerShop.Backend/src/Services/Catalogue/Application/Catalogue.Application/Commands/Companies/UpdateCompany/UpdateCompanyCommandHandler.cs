using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Mapper;
using System.Threading.Tasks;

namespace Catalogue.Application.Commands.Companies.UpdateCompany
{
    public class UpdateCompanyCommandHandler : ICommandHandler<UpdateCompanyCommand>
    {
        private readonly ICompanyProccesing _companyProccesing;
        public UpdateCompanyCommandHandler(ICompanyProccesing companyProccesing)
        {
            _companyProccesing = companyProccesing;
        }
        public async Task HandleAsync(UpdateCompanyCommand command)
        {
            var mapper = Mapping.UpdateCommandCompany(command);
            await _companyProccesing.UpdateCompanyAsync(mapper);
        }
    }
}
