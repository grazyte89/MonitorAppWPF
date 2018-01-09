using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.MenuControlsVm.DbSubMenuVm
{
    public class AnimalDbCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public AnimalDbCommand()
        {

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
