using IrenaProjekatBaze.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IrenaProjekatBaze.Command
{
    internal class LogInCommand : ICommand
    {
        private MainWindowViewModel mainWindowViewModel;

        public LogInCommand(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return mainWindowViewModel.CanLogIn;
        }

        public void Execute(object parameter)
        {
            mainWindowViewModel.LogIn();
        }
    }
}
