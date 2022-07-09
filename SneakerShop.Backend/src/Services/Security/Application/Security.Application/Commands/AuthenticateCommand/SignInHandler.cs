using Security.Application.Abstraction;
using Security.Application.Dto;
using Security.Application.Exceptions;
using Security.Application.Security;
using Security.Application.Security.TokenGenerators;
using Security.Domain.Entities;
using System.Threading.Tasks;

namespace Security.Application.Commands.AuthenticateCommand
{
    public class SignInHandler : ICommandHandler<SignIn>
    {
        private readonly IUserRepository _userRepository;
        private readonly AccessTokenGenerator _accessTokenGenerator;
        private readonly RefreshTokenGenerator _refreshTokenGenerator;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IPasswordManager _passwordManager;
        private readonly ITokenStorage _tokenStorage;

        public SignInHandler(
            IUserRepository userRepository,
            AccessTokenGenerator accessTokenGenerator,
            RefreshTokenGenerator refreshTokenGenerator,
            IRefreshTokenRepository refreshTokenRepository,
            IPasswordManager passwordManager,
            ITokenStorage tokenStorage)
        {
            _userRepository = userRepository;
            _accessTokenGenerator = accessTokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
            _refreshTokenRepository = refreshTokenRepository;
            _passwordManager = passwordManager;
            _tokenStorage = tokenStorage;
        }

        public async Task HandleAsync(SignIn command)
        {
            var existingUser = await _userRepository.GetByLoginAsync(command.Login);

            if (existingUser == null)
                throw new NotFoundLoginException(command.Login);

            bool isCorrectPassword = _passwordManager.Validate(command.Password, existingUser.Password);

            if (!isCorrectPassword)
                throw new InvalidPasswordException(command.Password);

            AccessToken accessToken = _accessTokenGenerator.GenerateToken(existingUser);

            string refreshToken = _refreshTokenGenerator.GenerateToken();

            RefreshToken refreshTokenDTO = new RefreshToken()
            {
                Token = refreshToken,
                UserId = existingUser.UserId
            };

            await _refreshTokenRepository.Create(refreshTokenDTO);

            var result = new JwtDto()
            {
                AccessToken = accessToken.Value,
                RefreshToken = refreshToken
            };

            _tokenStorage.Set(result);
        }
    }
}
