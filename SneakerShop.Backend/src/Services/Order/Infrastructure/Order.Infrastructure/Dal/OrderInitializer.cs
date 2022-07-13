using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Order.Infrastructure.Dal
{
    public class OrderInitializer
    {
        private readonly ILogger<OrderInitializer> _logger;
        private readonly OrderContext _context;

        public OrderInitializer(ILogger<OrderInitializer> logger, OrderContext context)
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
