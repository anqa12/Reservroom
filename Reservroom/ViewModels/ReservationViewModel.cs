using Reservroom.Models;

namespace Reservroom.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        private readonly Reservation _reservation;
        public string RoomID => _reservation.RoomID.ToString();
        public string Username => _reservation.Username;
        public string StartDateFormatted => _reservation.StartDate.ToString("d");
        public string EndDateFormatted => _reservation.EndDate.ToString("d");

        public ReservationViewModel(Reservation reservation)
        {
            _reservation = reservation;
        }
    }
}
