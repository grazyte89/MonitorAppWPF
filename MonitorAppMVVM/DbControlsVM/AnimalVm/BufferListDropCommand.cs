using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.AnimalVm
{
    public class BufferListDropCommand : ICommand
    {
        private AnimalViewModel _animalViewModel;

        public event EventHandler CanExecuteChanged;

        public BufferListDropCommand(AnimalViewModel animalViewModel)
        {
            _animalViewModel = animalViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_animalViewModel.SelectedAnimal == null)
            {
                return;
            }

            try
            {
                var alreadyInList = _animalViewModel.AnimalBufferList
                        .Any(a => a.ID == _animalViewModel.SelectedAnimal.ID);
                if (!alreadyInList)
                {
                    _animalViewModel.AnimalBufferList.Add(_animalViewModel.SelectedAnimal);
                    _animalViewModel.AnimalsList.Remove(_animalViewModel.SelectedAnimal);
                }
            }
            catch (Exception exception)
            {
                _animalViewModel.RaiseAnimalVmErrorMessage("Error encountered when dropping animal to buffer list.");
            }
        }
    }
}