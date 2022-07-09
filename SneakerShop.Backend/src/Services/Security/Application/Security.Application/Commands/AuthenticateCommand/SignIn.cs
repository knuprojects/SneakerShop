using Security.Application.Abstraction;

namespace Security.Application.Commands.AuthenticateCommand
{
    public class SignIn : ICommand
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
