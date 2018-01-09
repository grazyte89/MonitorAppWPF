using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.MenuControlsVm.DbSubMenuVm
{
    public class DBSubMenuControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private AnimalDbCommand _animalDbCommand;
        public ICommand AnimalDbCommand
        {
            get
            {
                return _animalDbCommand;
            }
        }
    }
}
