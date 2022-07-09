using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Security.Infrastructure.Dal
{
    public class SecurityInitializer
    {
        private readonly ILogger<SecurityInitializer> _logger;
        private readonly SecurityContext _context;

        public SecurityInitializer(ILogger<SecurityInitializer> logger, SecurityContext context)
        {
            (_logger, _context) = (logger, context);
        }

        public async Task InitializeAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }
    }
}
