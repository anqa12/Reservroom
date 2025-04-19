using Reservroom.Models;

namespace Reservroom.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }
        public MainViewModel(Hotel hotel)
        {
            // Initialize the current view model to the reservation listing view model
            CurrentViewModel = new MakeReservationViewModel(hotel);
        }
    }
}
