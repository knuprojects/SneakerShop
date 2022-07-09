using Microsoft.EntityFrameworkCore;
using Security.Application.Security;
using Security.Domain.Entities;
using Security.Infrastructure.Dal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Infrastructure.Security
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly SecurityContext _context;

        public RefreshTokenRepository(SecurityContext context)
        {
            _context = context;
        }

        public async Task<RefreshToken> GetByTokenAsync(string token)
        {
            return await _context.RefreshToken.FirstOrDefaultAsync(x => x.Token == token);
        }

        public async Task Create(RefreshToken refreshToken)
        {
            await _context.RefreshToken.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var refreshTokenById = await _context.RefreshToken.FindAsync(id);
            _context.RefreshToken.Remove(refreshTokenById);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(int userId)
        {
            IEnumerable<RefreshToken> refreshTokens = await _context.RefreshToken
                .Where(t => t.UserId == userId)
                .ToListAsync();

            _context.RefreshToken.RemoveRange(refreshTokens);
            await _context.SaveChangesAsync();
        }
    }
}
