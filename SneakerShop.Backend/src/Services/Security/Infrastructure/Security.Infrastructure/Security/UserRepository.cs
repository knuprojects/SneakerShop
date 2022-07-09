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

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetByLoginAsync(string login)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task AddAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
