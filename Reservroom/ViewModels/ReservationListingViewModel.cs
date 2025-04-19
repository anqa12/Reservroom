using System.Collections.ObjectModel;
using System.Windows.Input;
using Reservroom.Models;

namespace Reservroom.ViewModels
{
    class ReservationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;
        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ICommand? MakeReservationCommand { get; }



        public ReservationListingViewModel()
        {
            _reservations = new ObservableCollection<ReservationViewModel>();

            // Example data
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(1, 2), "Alice", DateTime.Now, DateTime.Now.AddHours(1))));
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(3, 2), "Bob", DateTime.Now.AddHours(1), DateTime.Now.AddHours(2))));
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(2, 4), "Charlie", DateTime.Now.AddHours(2), DateTime.Now.AddHours(3))));
        }
    }
}
