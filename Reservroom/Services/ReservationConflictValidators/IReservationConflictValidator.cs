using Reservroom.Models;

namespace Reservroom.Services.ReservationConflictValidators
{
    public interface IReservationConflictValidator
    {
        Task<Reservation?> GetConflictingReservation(Reservation reservation);
    }
}
