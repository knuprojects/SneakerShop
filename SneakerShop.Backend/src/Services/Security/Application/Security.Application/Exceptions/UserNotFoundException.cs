using Security.Domain.Entities;

namespace Security.Application.Exceptions
{
    public class UserNotFoundException : CustomException
    {
        public AppUser User { get; }

        public UserNotFoundException(AppUser user) : base($"User: {user} is invalid!")
        {
            User = user;
        }
    }
}
