using System.Collections.ObjectModel;
using System.Windows.Input;
using Reservroom.Commands;
using Reservroom.Models;
using Reservroom.Services;

namespace Reservroom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly Hotel _hotel;
        private readonly ObservableCollection<ReservationViewModel> _reservations;
        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ICommand? MakeReservationCommand { get; }



        public ReservationListingViewModel(Hotel hotel, NavigationService makeReservationNavigationService)
        {
            _hotel = hotel;
            _reservations = new ObservableCollection<ReservationViewModel>();

            MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);

            // Example data
            //_reservations.Add(new ReservationViewModel(new Reservation(new RoomID(1, 2), "Alice", DateTime.Now, DateTime.Now.AddHours(1))));
            //_reservations.Add(new ReservationViewModel(new Reservation(new RoomID(3, 2), "Bob", DateTime.Now.AddHours(1), DateTime.Now.AddHours(2))));
            //_reservations.Add(new ReservationViewModel(new Reservation(new RoomID(2, 4), "Charlie", DateTime.Now.AddHours(2), DateTime.Now.AddHours(3))));

            // Load reservations from the hotel
            UpdateReservations();
        }
        private void UpdateReservations()
        {
            _reservations.Clear();
            foreach (Reservation reservation in _hotel.GetAllReservations())
            {
                ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
                _reservations.Add(reservationViewModel);
            }
        }
    }
}
