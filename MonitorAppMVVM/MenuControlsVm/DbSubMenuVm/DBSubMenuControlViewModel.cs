using MonitorAppMVVM.DbControlsVM.VmSharedGeneric;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.MenuControlsVm.DbSubMenuVm
{
    public class DBSubMenuControlViewModel : GenericBaseViewModel
    {
        public string CurrentViewModelName { get { return "DBSubMenuControlViewModel"; } }

        private AnimalDbCommand _animalDbCommand;
        public ICommand AnimalDbCommand
        {
            get
            {
                return _animalDbCommand;
            }
        }

        public DBSubMenuControlViewModel()
        {
            _animalDbCommand = new AnimalDbCommand(this);
        }
    }
}
