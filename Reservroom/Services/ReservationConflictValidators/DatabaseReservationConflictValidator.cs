using Microsoft.EntityFrameworkCore;
using Reservroom.DbContexts;
using Reservroom.DTOs;
using Reservroom.Models;

namespace Reservroom.Services.ReservationConflictValidators
{
    public class DatabaseReservationConflictValidator : IReservationConflictValidator
    {
        private readonly ReservroomDbContextFactory _dbContextFactory;

        public DatabaseReservationConflictValidator(ReservroomDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Reservation?> GetConflictingReservation(Reservation reservation)
        {
            using (ReservroomDbContext context = _dbContextFactory.CreateDbContext())
            {
                ReservationDTO? reservationDTO = await context.Reservations
                    .Where(r => r.FloorNum == reservation.RoomID.FloorNum)
                    .Where(r => r.RoomNum == reservation.RoomID.RoomNum)
                    .Where(r => r.StartDate < reservation.EndDate)
                    .Where(r => r.EndDate > reservation.StartDate)
                    .FirstOrDefaultAsync();

                if (reservationDTO == null)
                {
                    return null;
                }

                return ToReservation(reservationDTO);
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
