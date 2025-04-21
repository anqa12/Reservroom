using System.Windows;
using Reservroom.Stores;
using Reservroom.ViewModels;

namespace Reservroom.Commands
{
    public class LoadReservationsCommand : AsyncCommandBase
    {
        private readonly ReservationListingViewModel _viewModel;
        private readonly HotelStore _hotelStore;

        public LoadReservationsCommand(ReservationListingViewModel reservationListingViewModel, HotelStore hotelStore)
        {
            _viewModel = reservationListingViewModel;
            _hotelStore = hotelStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                await _hotelStore.Load();
                _viewModel.UpdateReservations(_hotelStore.Reservations);

            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load reservation.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
