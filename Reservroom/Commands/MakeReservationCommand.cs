using System.ComponentModel;
using System.Windows;
using Reservroom.Exceptions;
using Reservroom.Models;
using Reservroom.Services;
using Reservroom.ViewModels;

namespace Reservroom.Commands
{
    class MakeReservationCommand : CommandBase
    {
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly Hotel _hotel;
        private readonly NavigationService _reservationViewNavigationService;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel, NavigationService reservationViewNavigationService)
        {
            _makeReservationViewModel = makeReservationViewModel;
            _hotel = hotel;
            this._reservationViewNavigationService = reservationViewNavigationService;
            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }



        // Disable the submit button if the username is empty
        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_makeReservationViewModel.Username) &&
                _makeReservationViewModel.FloorNumber > 0 &&
                _makeReservationViewModel.RoomNumber > 0 &&
                _makeReservationViewModel.StartDate < _makeReservationViewModel.EndDate &&
                _makeReservationViewModel.StartDate >= DateTime.Now &&
                _makeReservationViewModel.EndDate >= DateTime.Now &&
                base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            Reservation reservation = new Reservation(
                new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber),
                _makeReservationViewModel.Username,
                _makeReservationViewModel.StartDate,
                _makeReservationViewModel.EndDate);

            // Check if the reservation conflicts with existing reservations
            try
            {
                _hotel.MakeReservation(reservation);

                MessageBox.Show("Reservation made successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _reservationViewNavigationService.Navigate();

            }
            catch (ReservationConflictException)
            {
                MessageBox.Show("Reservation conflicts with an existing reservation.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeReservationViewModel.Username) ||
                e.PropertyName == nameof(MakeReservationViewModel.RoomNumber) ||
                e.PropertyName == nameof(MakeReservationViewModel.FloorNumber) ||
                e.PropertyName == nameof(MakeReservationViewModel.StartDate) ||
                e.PropertyName == nameof(MakeReservationViewModel.EndDate))
            {
                OnCanExecuteChanged();
            }
        }

    }
}
