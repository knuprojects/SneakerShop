using Security.Domain.Entities;
using System.Threading.Tasks;

namespace Security.Application.Security
{
    public interface IUserRepository
    {
        Task<AppUser> GetByEmailAsync(string email);
        Task<AppUser> GetByLoginAsync(string login);
        Task<AppUser> GetByIdAsync(int userId);
        Task AddAsync(AppUser user);
    }
}
