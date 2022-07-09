using Security.Domain.Entities;
using System.Threading.Tasks;

namespace Security.Application.Security
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetByTokenAsync(string token);

        Task Create(RefreshToken refreshToken);

        Task DeleteAsync(int id);

        Task DeleteAllAsync(int userId);
    }
}
