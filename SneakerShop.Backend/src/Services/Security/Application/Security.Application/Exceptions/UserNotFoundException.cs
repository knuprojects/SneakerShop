using Security.Domain.Entities;

namespace Security.Application.Exceptions
{
    public class UserNotFoundException : CustomException
    {
        public User User { get; }

        public UserNotFoundException(User user) : base($"User: {user} is invalid!")
        {
            User = user;
        }
    }
}
