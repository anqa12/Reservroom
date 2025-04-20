using Microsoft.EntityFrameworkCore;
using Reservroom.DTOs;

namespace Reservroom.DbContexts
{
    public class ReservroomDbContext : DbContext
    {
        public ReservroomDbContext(DbContextOptions options) : base(options)
        {
        }

        // DTO = Data Transfer Object (transfers the data between aplication and database)
        public DbSet<ReservationDTO> Reservations { get; set; }
    }
}
