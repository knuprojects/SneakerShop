using Catalogue.Application.Abstraction;
using Catalogue.Application.Contracts.Processing;
using Catalogue.Application.Mapper;
using System.Threading.Tasks;

namespace Catalogue.Application.Commands.Companies.CreateCompany
{
    public class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand>
    {
        private readonly ICompanyProccesing _companyProccesing;
        public CreateCompanyCommandHandler(ICompanyProccesing companyProccesing)
        {
            _companyProccesing = companyProccesing;
        }
        public async Task HandleAsync(CreateCompanyCommand command)
        {
            var mapper = Mapping.CreateCommandCompany(command);
            await _companyProccesing.CreateCompanyAsync(mapper);
        }
    }
}
