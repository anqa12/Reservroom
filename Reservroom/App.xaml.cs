using System.Windows;
using Microsoft.EntityFrameworkCore;
using Reservroom.DbContexts;
using Reservroom.Models;
using Reservroom.Services;
using Reservroom.Services.ReservationConflictValidators;
using Reservroom.Services.ReservationCreators;
using Reservroom.Services.ReservationProviders;
using Reservroom.Stores;
using Reservroom.ViewModels;

namespace Reservroom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source=reservroom.db";

        private readonly Hotel _hotel;
        private readonly HotelStore _hotelStore;
        private readonly NavigationStore _navigationStore;
        private ReservroomDbContextFactory _reservroomDbContextFactory;

        public App()
        {
            _reservroomDbContextFactory = new ReservroomDbContextFactory(CONNECTION_STRING);
            IReservationProvider reservationProvider = new DatabaseReservationProvider(_reservroomDbContextFactory);
            IReservationCreator reservationCreator = new DatabaseReservationCreator(_reservroomDbContextFactory);
            IReservationConflictValidator reservationConflictValidator = new DatabaseReservationConflictValidator(_reservroomDbContextFactory);

            ReservationBook reservationBook = new ReservationBook(reservationProvider, reservationCreator, reservationConflictValidator);
            _hotel = new Hotel("Anqa Hotel", reservationBook);
            _hotelStore = new HotelStore(_hotel);
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            // Initialize the database context and apply migrations in the bin directory
            DbContextOptions options = new DbContextOptionsBuilder()
                .UseSqlite(CONNECTION_STRING)
                .Options;
            using (ReservroomDbContext dbContext = new ReservroomDbContext(options))
            {
                dbContext.Database.Migrate();
            }


            _navigationStore.CurrentViewModel = CreateReservationListingViewModel();

            // Create the main window and set its DataContext to a new instance of MainViewModel
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private MakeReservationViewModel CreateMakeReservationViewModel()
        {
            return new MakeReservationViewModel(_hotelStore, new NavigationService(_navigationStore, CreateReservationListingViewModel));
        }

        private ReservationListingViewModel CreateReservationListingViewModel()
        {
            return ReservationListingViewModel.LoadViewModel(_hotelStore, new NavigationService(_navigationStore, CreateMakeReservationViewModel));
        }
    }

}
