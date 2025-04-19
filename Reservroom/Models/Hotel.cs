using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="username"></param>
        /// <returns>The reservation for the user.</returns>
        public IEnumerable<Reservation> GetReservationsForUser(string username)
        {
            return _reservationBook.GetReservationsForUser(username);
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
