using Security.Application.Abstraction;
using Security.Application.Exceptions;
using Security.Application.Security;
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

        public SignUpHandler(
            IUserRepository userRepository,
            IPasswordManager passwordManager,
            IClock clock)
        {
            _userRepository = userRepository;
            _passwordManager = passwordManager;
            _clock = clock;
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
        }
    }
}
