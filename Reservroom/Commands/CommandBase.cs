using System.Windows.Input;

namespace Reservroom.Commands
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);

        protected void OnCanExecuteChanged()
        {
            // Notify that the CanExecute state has changed
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
