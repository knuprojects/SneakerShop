using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Catalogue.Infrastructure.Dal
{
    public class Catalogueinitializer
    {
        private readonly ILogger<Catalogueinitializer> _logger;
        private readonly CatalogueContext _context;

        public Catalogueinitializer(ILogger<Catalogueinitializer> logger, CatalogueContext context)
        {
            _context = context;
            _logger = logger;
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
