using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservroom.Models
{
    public class Reservation
    {
        public RoomID RoomID { get; }
        public string UserName { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public TimeSpan Duration => EndDate - StartDate;

        public Reservation(RoomID roomID, string username, DateTime startDate, DateTime endDate)
        {
            RoomID = roomID;
            UserName = username;
            StartDate = startDate;
            EndDate = endDate;
        }

        public bool Conflicts(Reservation reservation)
        {
            if (reservation.RoomID != RoomID)
            {
                return false;
            }

            // Check if the reservations overlap
            return reservation.StartDate < EndDate && reservation.EndDate > StartDate;
        }
    }
}
