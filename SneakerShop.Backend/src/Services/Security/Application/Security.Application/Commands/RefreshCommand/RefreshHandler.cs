using Security.Application.Abstraction;
using Security.Application.Security;
using Security.Application.Security.TokenValidator;
using System;
using System.Threading.Tasks;

namespace Security.Application.Commands.RefreshCommand
{
    public class RefreshHandler : ICommandHandler<Refresh>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly RefreshTokenValidator _refreshTokenValidator;

        public RefreshHandler(
            IUserRepository userRepository,
            IRefreshTokenRepository refreshTokenRepository,
            RefreshTokenValidator refreshTokenValidator)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _refreshTokenValidator = refreshTokenValidator;
        }

        public async Task HandleAsync(Refresh command)
        {
            throw new NotImplementedException();
        }
    }
}
