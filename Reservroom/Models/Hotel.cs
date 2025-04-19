namespace Reservroom.Models
{
    public class Hotel
    {
        private readonly ReservationBook _reservationBook;
        private string Name { get; }

        public Hotel(string name)
        {
            Name = name;
            _reservationBook = new ReservationBook();
        }

        /// <summary>
        /// Get the reservations for user.
        /// </summary>
        /// <returns>All reservations in tyhe hotel reservation book.</returns>
        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationBook.GetAllReservations();
        }

        /// <summary>
        /// Make a reservation.
        /// </summary>
        /// <param name="reservation">The incoming reservation.</param>
        public void MakeReservation(Reservation reservation)
        {
            _reservationBook.AddReservation(reservation);
        }

    }
}
