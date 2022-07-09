namespace Security.Application.Exceptions
{
    public sealed class NotFoundLoginException : CustomException
    {
        public string Login { get; }

        public NotFoundLoginException(string login) : base($"User with this login: {login} wasn't found!")
        {
            Login = login;
        }
    }
}
