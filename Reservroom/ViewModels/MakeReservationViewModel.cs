using System.Windows.Input;
using Reservroom.Commands;
using Reservroom.Models;

namespace Reservroom.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase
    {
        private string _username = string.Empty;
        private int _roomNumber;
        private int _floorNumber;
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now.AddDays(1);

        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }
        public int RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                if (_roomNumber != value)
                {
                    _roomNumber = value;
                    OnPropertyChanged(nameof(RoomNumber));
                }
            }
        }
        public int FloorNumber
        {
            get { return _floorNumber; }
            set
            {
                if (_floorNumber != value)
                {
                    _floorNumber = value;
                    OnPropertyChanged(nameof(FloorNumber));
                }
            }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }



        public ICommand? SubmitCommand { get; }
        public ICommand? CancelCommand { get; }

        public MakeReservationViewModel(Hotel hotel)
        {
            SubmitCommand = new MakeReservationCommand(this, hotel);
            CancelCommand = new CancelMakeReservationCommand();
        }

    }
}
