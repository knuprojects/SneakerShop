using Security.Application.Abstraction;
using Security.Application.Dto;
using Security.Application.Exceptions;
using Security.Application.Security;
using Security.Application.Security.TokenGenerators;
using Security.Application.Security.TokenValidator;
using Security.Domain.Entities;
using System.Threading.Tasks;

namespace Security.Application.Commands.RefreshCommand
{
    public class RefreshHandler : ICommandHandler<Refresh>
    {
        private readonly IUserRepository _userRepository;
        private readonly AccessTokenGenerator _accessTokenGenerator;
        private readonly RefreshTokenGenerator _refreshTokenGenerator;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly RefreshTokenValidator _refreshTokenValidator;
        private readonly IPasswordManager _passwordManager;
        private readonly ITokenStorage _tokenStorage;

        public RefreshHandler(
            IUserRepository userRepository,
            AccessTokenGenerator accessTokenGenerator,
            RefreshTokenGenerator refreshTokenGenerator,
            IRefreshTokenRepository refreshTokenRepository,
            RefreshTokenValidator refreshTokenValidator,
            IPasswordManager passwordManager,
            ITokenStorage tokenStorage)
        {
            _userRepository = userRepository;
            _accessTokenGenerator = accessTokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
            _refreshTokenRepository = refreshTokenRepository;
            _refreshTokenValidator = refreshTokenValidator;
            _passwordManager = passwordManager;
            _tokenStorage = tokenStorage;
        }

        public async Task HandleAsync(Refresh command)
        {
            bool isValidRefreshToken = _refreshTokenValidator.Validate(command.Token);

            if (!isValidRefreshToken)
                throw new InvalidRefreshToken(command.Token);

            RefreshToken refreshTokenDTO = await _refreshTokenRepository.GetByTokenAsync(command.Token);

            if (refreshTokenDTO == null)
                throw new InvalidRefreshToken(command.Token);

            await _refreshTokenRepository.DeleteAsync(refreshTokenDTO.RefreshTokenId);
            AppUser user = await _userRepository.GetByIdAsync(refreshTokenDTO.UserId);

            if (user == null)
                throw new UserNotFoundException(user);

            var existingUser = await _userRepository.GetByLoginAsync(user.Login);

            if (existingUser == null)
                throw new NotFoundLoginException(user.Login);

            AccessToken accessToken = _accessTokenGenerator.GenerateToken(existingUser);

            string refreshToken = _refreshTokenGenerator.GenerateToken();

            RefreshToken newRefreshTokenDTO = new RefreshToken()
            {
                Token = refreshToken,
                UserId = existingUser.UserId
            };

            await _refreshTokenRepository.Create(newRefreshTokenDTO);

            var result = new JwtDto()
            {
                AccessToken = accessToken.Value,
                RefreshToken = refreshToken
            };

            _tokenStorage.Set(result);
        }
    }
}
