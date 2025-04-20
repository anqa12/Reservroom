using Reservroom.DbContexts;
using Reservroom.DTOs;
using Reservroom.Models;

namespace Reservroom.Services.ReservationCreators
{
    public class DatabaseReservationCreator : IReservationCreator
    {
        private readonly ReservroomDbContextFactory _dbContextFactory;

        public DatabaseReservationCreator(ReservroomDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateReservation(Reservation reservation)
        {
            using (ReservroomDbContext context = _dbContextFactory.CreateDbContext())
            {
                ReservationDTO reservationDTO = ToReservationDTO(reservation);

                context.Reservations.Add(reservationDTO);
                await context.SaveChangesAsync();
            }
        }

        private ReservationDTO ToReservationDTO(Reservation reservation)
        {
            return new ReservationDTO()
            {
                FloorNum = reservation.RoomID?.FloorNum ?? 0,
                RoomNum = reservation.RoomID?.RoomNum ?? 0,
                Username = reservation.Username,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate
            };
        }
    }
}
