using Security.Application.Abstraction;
using Security.Application.Dto;
using Security.Application.Exceptions;
using Security.Application.Security;
using Security.Application.Security.TokenGenerators;
using Security.Domain.Abstraction;
using Security.Domain.Entities;
using Security.Domain.ValueObjects;
using System.Threading.Tasks;

namespace Security.Application.Commands.RegisterCommand
{
    public class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordManager _passwordManager;
        private readonly IClock _clock;
        private readonly AccessTokenGenerator _accessTokenGenerator;
        private readonly RefreshTokenGenerator _refreshTokenGenerator;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ITokenStorage _tokenStorage;

        public SignUpHandler(
            IUserRepository userRepository,
            IPasswordManager passwordManager,
            IClock clock,
            AccessTokenGenerator accessTokenGenerator,
            RefreshTokenGenerator refreshTokenGenerator,
            IRefreshTokenRepository refreshTokenRepository,
            ITokenStorage tokenStorage)
        {
            _userRepository = userRepository;
            _passwordManager = passwordManager;
            _clock = clock;
            _accessTokenGenerator = accessTokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
            _refreshTokenRepository = refreshTokenRepository;
            _tokenStorage = tokenStorage;
        }

        public async Task HandleAsync(SignUp command)
        {
            var login = new Login(command.Login);
            var email = new Email(command.Email);
            var password = new Password(command.Password);
            var role = string.IsNullOrWhiteSpace(command.Role) ? Role.User() : new Role(command.Role);

            var existingLogin = await _userRepository.GetByLoginAsync(command.Login);

            if (existingLogin != null)
                throw new LoginAlreadyExist(command.Login);

            var existingEmail = await _userRepository.GetByEmailAsync(command.Email);

            if (existingEmail != null)
                throw new EmailAlreadyExist(command.Email);

            var securePassword = _passwordManager.Secure(password);

            var user = new AppUser
            {
                Login = login,
                Password = securePassword,
                Role = role,
                Email = email,
                CreatedAt = _clock.Current(),
                Deleted = false
            };

            await _userRepository.AddAsync(user);

            AccessToken accessToken = _accessTokenGenerator.GenerateToken(existingLogin);

            string refreshToken = _refreshTokenGenerator.GenerateToken();

            RefreshToken refreshTokenDTO = new RefreshToken()
            {
                Token = refreshToken,
                UserId = existingLogin.UserId
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
