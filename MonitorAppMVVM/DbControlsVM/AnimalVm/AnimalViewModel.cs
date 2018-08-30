using MonitorAppMVVM.VmSharedGeneric;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.AnimalVm
{
    public class AnimalViewModel : IGenericBaseViewModel, INotifyPropertyChanged
    {
        public string CurrentViewModelName { get { return "AnimalViewModel"; } }

        public event PropertyChangedEventHandler PropertyChanged;
        public event ViewModelMessageEventHandler AnimalVmErrorMessage;

        public string ExistingOrNewAnimal { get; set; }

        private Animal _currentAnimal;
        public Animal CurrentAnimal
        {
            get
            {
                return _currentAnimal;
            }
            set
            {
                _currentAnimal = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentAnimal"));
            }
        }

        private Animal _selectedAnimal;
        public Animal SelectedAnimal
        {
            get
            {
                return _selectedAnimal;
            }
            set
            {
                _selectedAnimal = value;
                //CurrentAnimal = _selectedAnimal;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedAnimal"));
            }
        }

        private Animal _selectedBufferAnimal;
        public Animal SelectedBufferAnimal
        {
            get
            {
                return _selectedBufferAnimal;
            }
            set
            {
                _selectedBufferAnimal = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedBufferAnimal"));
            }
        }

        private ObservableCollection<Animal> _animalsList;
        public ObservableCollection<Animal> AnimalsList
        {
            get
            {
                return _animalsList;
            }
            set
            {
                _animalsList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AnimalsList"));
            }
        }

        private ObservableCollection<Animal> _animalBufferList;
        public ObservableCollection<Animal> AnimalBufferList
        {
            get
            {
                return _animalBufferList;
            }
            set
            {
                _animalBufferList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AnimalBufferList"));
            }
        }

        private bool _animalListAccessEnabled;
        public bool AnimalListAccessEnabled
        {
            get
            {
                return _animalListAccessEnabled;
            }
            set
            {
                _animalListAccessEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AnimalListAccessEnabled"));
            }
        }

        private RetrieveAnimalsCommand _retrieveAnimalCommand;
        public ICommand RetrieveAnimalCommand
        {
            get
            {
                return _retrieveAnimalCommand;
            }
        }

        private NewAnimalCommand _newAnimalCommand;
        public ICommand NewAnimalCommand
        {
            get
            {
                return _newAnimalCommand;
            }
        }

        private EditAnimalCommand _editAnimalCommand;
        public ICommand EditAnimalCommand
        {
            get
            {
                return _editAnimalCommand;
            }
        }

        private SaveAnimalCommand _saveAnimalCommand;
        public ICommand SaveAnimalCommand
        {
            get
            {
                return _saveAnimalCommand;
            }
        }

        private CancelEditCommand _cancelEditCommand;
        public ICommand CancelEditCommand
        {
            get
            {
                return _cancelEditCommand;
            }
        }

        private BufferListDropCommand _bufferListDropCommand;
        public ICommand BufferListDropCommand
        {
            get
            {
                return _bufferListDropCommand;
            }
        }

        private AnimalListDropCommand _animalListDropCommand;
        public ICommand AnimalListDropCommand
        {
            get
            {
                return _animalListDropCommand;
            }
        }

        private DeleteAnimalCommand _deleteAnimalCommand;
        public ICommand DeleteAnimalCommand
        {
            get
            {
                return _deleteAnimalCommand;
            }
        }

        public AnimalViewModel()
        {
            _animalsList = new ObservableCollection<Animal>();
            _animalBufferList = new ObservableCollection<Animal>();
            _retrieveAnimalCommand = new RetrieveAnimalsCommand(this);
            _editAnimalCommand = new EditAnimalCommand(this);
            _newAnimalCommand = new NewAnimalCommand(this);
            _saveAnimalCommand = new SaveAnimalCommand(this);
            _cancelEditCommand = new CancelEditCommand(this);
            _bufferListDropCommand = new BufferListDropCommand(this);
            _animalListDropCommand = new AnimalListDropCommand(this);
            _deleteAnimalCommand = new DeleteAnimalCommand(this);
        }

        public void RaiseAnimalVmErrorMessage(string errorMessage)
        {
            if (AnimalVmErrorMessage != null)
            {
                AnimalVmErrorMessage.Invoke(this, new ViewModelMessageEventArgs(errorMessage));
            }
        }
    }
}
