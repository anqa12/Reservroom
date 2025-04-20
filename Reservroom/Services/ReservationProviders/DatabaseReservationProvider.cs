using Microsoft.EntityFrameworkCore;
using Reservroom.DbContexts;
using Reservroom.DTOs;
using Reservroom.Models;

namespace Reservroom.Services.ReservationProviders
{
    public class DatabaseReservationProvider : IReservationProvider
    {
        private readonly ReservroomDbContextFactory _dbContextFactory;

        public DatabaseReservationProvider(ReservroomDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            using (ReservroomDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<ReservationDTO> reservationDTOs = await context.Reservations.ToListAsync();

                return reservationDTOs.Select(r => ToReservation(r));
            }
        }

        private static Reservation ToReservation(ReservationDTO reservationDTO)
        {
            return new Reservation(
                new RoomID(reservationDTO.FloorNum, reservationDTO.RoomNum),
                reservationDTO.Username,
                reservationDTO.StartDate,
                reservationDTO.EndDate);
        }
    }
}
