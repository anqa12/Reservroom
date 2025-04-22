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
            _viewModel.ErrorMsg = string.Empty;
            _viewModel.IsLoading = true;

            try
            {
                await _hotelStore.Load();
                _viewModel.UpdateReservations(_hotelStore.Reservations);

            }
            catch (Exception)
            {
                _viewModel.ErrorMsg = "Failed to load reservations.";
            }
            _viewModel.IsLoading = false;
        }
    }
}
