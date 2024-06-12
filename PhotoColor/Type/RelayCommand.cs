using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhotoColor.Type
{
    public class Command : ICommand
    {
        //метод команды
        public Action Action { get; set; }

        //имя для отображание команды
        public string DisplayName { get; set; }

        //вызов команды
        public void Execute(object parameter)
        {
            Action?.Invoke();

        }

        //может ли вызваться команда
        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        //доступна ли команда
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        private bool _isEnabled = true;


        public event EventHandler CanExecuteChanged;

        public Command(Action action)
        {
            Action = action;
        }
    }

    public class Command<T> : ICommand
    {
        //метод команды
        public Action<T> Action { get; set; }

        //вызов команды
        public void Execute(object parameter)
        {
            if (Action != null && parameter is T)
                Action((T)parameter);
        }

        //может ли вызваться команда
        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        //доступна ли команда
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        private bool _isEnabled = true;

        public event EventHandler CanExecuteChanged;

        public Command(Action<T> action)
        {
            Action = action;
        }
    }}
