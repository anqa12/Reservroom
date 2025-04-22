using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using Reservroom.Commands;
using Reservroom.Services;
using Reservroom.Stores;

namespace Reservroom.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase, INotifyDataErrorInfo
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
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
                ClearErrors(nameof(StartDate));
                ClearErrors(nameof(EndDate));

                if (EndDate < StartDate)
                {
                    AddError("Start date must be before end date.", nameof(StartDate));

                }
            }
        }
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
                ClearErrors(nameof(StartDate));
                ClearErrors(nameof(EndDate));

                if (EndDate < StartDate)
                {
                    AddError("End date must be after start date.", nameof(EndDate));

                }


            }
        }

        private void AddError(string errorMessage, string propertyName)
        {
            if (!_errors.ContainsKey(propertyName))
            {
                _errors.Add(propertyName, new List<string>());
            }
            _errors[propertyName].Add(errorMessage);

            OnErrorsChanged(propertyName);

        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public ICommand? SubmitCommand { get; }
        public ICommand? CancelCommand { get; }

        private readonly Dictionary<string, List<string>> _errors;

        public bool HasErrors => _errors.Count > 0; // or _errors.Any()
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public MakeReservationViewModel(HotelStore hotelStore, NavigationService reservationViewNavigationService)
        {
            SubmitCommand = new MakeReservationCommand(this, hotelStore, reservationViewNavigationService);
            CancelCommand = new NavigateCommand(reservationViewNavigationService);
            _errors = new Dictionary<string, List<string>>();
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            return _errors.GetValueOrDefault(propertyName ?? string.Empty, new List<string>());
        }

        private void ClearErrors(string propertyName)
        {
            _errors.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }
    }
}
