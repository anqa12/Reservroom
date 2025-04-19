using System.Windows;
using Reservroom.Models;

namespace Reservroom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            Hotel hotel = new Hotel("Hotel California");

            try
            {
                hotel.MakeReservation(new Reservation(
                    new RoomID(1, 101),
                    "John Doe",
                    DateTime.Now,
                    DateTime.Now.AddDays(2)
                ));

                //hotel.MakeReservation(new Reservation(
                //    new RoomID(1, 101),
                //    "John Doe",
                //    DateTime.Now,
                //    DateTime.Now.AddDays(2)
                //));

                hotel.MakeReservation(new Reservation(
                    new RoomID(1, 102),
                    "Jane Doe",
                    DateTime.Now.AddDays(1),
                    DateTime.Now.AddDays(3)
                ));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            base.OnStartup(e);
        }
    }

}
