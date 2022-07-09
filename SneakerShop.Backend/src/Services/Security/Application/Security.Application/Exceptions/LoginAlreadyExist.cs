namespace Security.Application.Exceptions
{
    public sealed class LoginAlreadyExist : CustomException
    {
        public string Login { get; }

        public LoginAlreadyExist(string login) : base($"User with this login: {login} already exist!")
        {
            Login = login;
        }
    }
}
