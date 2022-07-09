namespace Security.Application.Exceptions
{
    public sealed class EmailAlreadyExist : CustomException
    {
        public string Email { get; }

        public EmailAlreadyExist(string email) : base($"User with this email: {email} already exist!")
        {
            Email = email;
        }
    }
}
