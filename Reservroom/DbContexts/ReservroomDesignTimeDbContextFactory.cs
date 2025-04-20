using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Reservroom.DbContexts
{
    public class ReservroomDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ReservroomDbContext>
    {
        public ReservroomDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=reservroom.db").Options;

            return new ReservroomDbContext(options);
        }
    }
}
