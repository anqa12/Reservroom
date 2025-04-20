using Microsoft.EntityFrameworkCore;

namespace Reservroom.DbContexts
{
    public class ReservroomDbContextFactory
    {
        private readonly string _connectionString;

        public ReservroomDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ReservroomDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new ReservroomDbContext(options);
        }
    }
}
