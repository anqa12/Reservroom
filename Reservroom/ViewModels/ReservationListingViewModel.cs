using System.Collections.ObjectModel;
using System.Windows.Input;
using Reservroom.Commands;
using Reservroom.Models;
using Reservroom.Services;
using Reservroom.Stores;

namespace Reservroom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;
        private readonly HotelStore _hotelStore;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;

        private string _errorMsg;
        public string ErrorMsg
        {
            get
            {
                return _errorMsg;
            }
            set
            {
                _errorMsg = value;
                OnPropertyChanged(nameof(ErrorMsg));
                OnPropertyChanged(nameof(HasErrorMsg));
            }
        }

        public bool HasErrorMsg => !string.IsNullOrEmpty(ErrorMsg);
        public ICommand? LoadReservationsCommand { get; }
        public ICommand? MakeReservationCommand { get; }

        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public ReservationListingViewModel(HotelStore hotelStore, NavigationService makeReservationNavigationService)
        {

            _reservations = new ObservableCollection<ReservationViewModel>();
            _hotelStore = hotelStore;

            LoadReservationsCommand = new LoadReservationsCommand(this, hotelStore);
            MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);

            _hotelStore.ReservationMade += OnReservationMode;
        }

        public override void Dispose()
        {
            // Unsubscribe from the event to avoid memory leaks
            _hotelStore.ReservationMade -= OnReservationMode;
            base.Dispose();
        }

        private void OnReservationMode(Reservation reservation)
        {
            ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
            _reservations.Add(reservationViewModel);
        }

        public static ReservationListingViewModel LoadViewModel(HotelStore hotelStore, NavigationService makeReservationNavigationService)
        {
            ReservationListingViewModel viewModel = new ReservationListingViewModel(hotelStore, makeReservationNavigationService);
            viewModel.LoadReservationsCommand?.Execute(null);
            return viewModel;
        }
        public void UpdateReservations(IEnumerable<Reservation> reservations)
        {
            _reservations.Clear();
            foreach (Reservation reservation in reservations)
            {
                ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
                _reservations.Add(reservationViewModel);
            }
        }

    }
}
