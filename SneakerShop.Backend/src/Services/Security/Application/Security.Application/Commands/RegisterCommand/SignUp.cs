using Security.Application.Abstraction;

namespace Security.Application.Commands.RegisterCommand
{
    public class SignUp : ICommand
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
