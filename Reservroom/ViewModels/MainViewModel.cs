namespace Reservroom.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }
        public MainViewModel()
        {
            // Initialize the current view model to the reservation listing view model
            CurrentViewModel = new ReservationListingViewModel();
        }
    }
}
