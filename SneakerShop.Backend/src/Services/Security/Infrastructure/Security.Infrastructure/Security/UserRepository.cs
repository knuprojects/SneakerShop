using Microsoft.EntityFrameworkCore;
using Security.Application.Security;
using Security.Domain.Entities;
using Security.Infrastructure.Dal;
using System.Threading.Tasks;

namespace Security.Infrastructure.Security
{
    public class UserRepository : IUserRepository
    {
        private readonly SecurityContext _context;

        public UserRepository(SecurityContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetByEmailAsync(string email)
        {
            return await _context.AppUser.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<AppUser> GetByLoginAsync(string login)
        {
            return await _context.AppUser.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<AppUser> GetByIdAsync(int userId)
        {
            return await _context.AppUser.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task AddAsync(AppUser user)
        {
            await _context.AppUser.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
