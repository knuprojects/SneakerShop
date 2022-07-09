using Security.Domain.Entities;
using System.Threading.Tasks;

namespace Security.Application.Security
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByLoginAsync(string login);
        Task<User> GetByIdAsync(int userId);
    }
}
