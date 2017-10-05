using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.AnimalSoldVm
{
    public class AnimalSoldViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string ExistingOrNewModel { get; set; }

        private IList<AnimalSold> _animalSoldList;
        public IList<AnimalSold> AnimalSoldList
        {
            get
            {
                return _animalSoldList;
            }
            set
            {
                _animalSoldList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AnimalSoldList"));
            }
        }

        private bool _animalSoldListAccessEnabled;
        public bool AnimalSoldListAccessEnabled
        {
            get
            {
                return _animalSoldListAccessEnabled;
            }
            set
            {
                _animalSoldListAccessEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AnimalSoldListAccessEnabled"));
            }
        }

        private AnimalSold _currentAnimalSold;
        public AnimalSold CurrentAnimalSold
        {
            get
            {
                return _currentAnimalSold;
            }
            set
            {
                _currentAnimalSold = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentAnimalSold"));
            }
        }

        private AnimalSold _selectedAnimalSold;
        public AnimalSold SelectedAnimalSold
        {
            get
            {
                return _selectedAnimalSold;
            }
            set
            {
                _selectedAnimalSold = value;
                CurrentAnimalSold = _selectedAnimalSold;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedAnimalSold"));
            }
        }

        private EditAnimalSoldCommand _editAnialSoldCommand;
        public ICommand EditAnimalSoldCommand
        {
            get
            {
                return _editAnialSoldCommand;
            }
        }

        private NewAnimalSoldCommand _newAnimalSoldCommand;
        public ICommand NewAnimaldSoldCommand
        {
            get
            {
                return _newAnimalSoldCommand;
            }
        }

        private RetrieveAnimalSoldCommand _retrieveAnimalSoldCommand;
        public ICommand RetrieveAnimalSoldCommand
        {
            get
            {
                return _retrieveAnimalSoldCommand;
            }
        }

        private SaveAnimalSoldCommand _saveAnimalSoldCommand;
        public ICommand SaveAnimalSoldCommand
        {
            get
            {
                return _saveAnimalSoldCommand;
            }
        }

        public AnimalSoldViewModel()
        {
            _editAnialSoldCommand = new EditAnimalSoldCommand(this);
            _newAnimalSoldCommand = new NewAnimalSoldCommand(this);
            _retrieveAnimalSoldCommand = new RetrieveAnimalSoldCommand(this);
            _saveAnimalSoldCommand = new SaveAnimalSoldCommand(this);
        }
    }
}
