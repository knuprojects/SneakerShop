using Security.Application.Security;

namespace Security.Infrastructure.Security
{
    public class PasswordManager : IPasswordManager
    {
        public string Secure(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Validate(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
