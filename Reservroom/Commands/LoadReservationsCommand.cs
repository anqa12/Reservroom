using System.Windows;
using Reservroom.Models;
using Reservroom.ViewModels;

namespace Reservroom.Commands
{
    public class LoadReservationsCommand : AsyncCommandBase
    {
        private readonly ReservationListingViewModel _viewModel;
        private readonly Hotel _hotel;

        public LoadReservationsCommand(ReservationListingViewModel reservationListingViewModel, Hotel hotel)
        {
            _viewModel = reservationListingViewModel;
            _hotel = hotel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                IEnumerable<Reservation> reservations = await _hotel.GetAllReservations();
                _viewModel.UpdateReservations(reservations);

            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load reservation.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
