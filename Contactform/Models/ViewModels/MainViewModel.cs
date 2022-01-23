using Contactform.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactform.Models.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        private object _currentView;

        public MainViewModel()
        {
            UserViewModel = new UserViewModel();
            NewUserViewModel = new NewUserViewModel();
            EventViewModel = new EventViewModel();
            NewEventViewModel = new NewEventViewModel();
            NewStatusViewModel = new NewStatusViewModel();
            StartViewModel = new StartViewModel();
            CurrentView = StartViewModel;

            UserViewCommand = new RelayCommand(x => CurrentView = UserViewModel);
            NewUserViewCommand = new RelayCommand(x => CurrentView = NewUserViewModel);
            EventViewCommand = new RelayCommand(x => CurrentView = EventViewModel);
            NewEventViewCommand = new RelayCommand(x => CurrentView = NewEventViewModel);
            NewStatusViewCommand = new RelayCommand(x => CurrentView = NewStatusViewModel);
            StartViewCommand = new RelayCommand(x => CurrentView = StartViewModel);
        }

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand UserViewCommand { get; set; }
        public UserViewModel UserViewModel { get; set; }

        public RelayCommand NewUserViewCommand { get; set; }
        public NewUserViewModel NewUserViewModel { get; set; }

        public RelayCommand EventViewCommand { get; set; }
        public EventViewModel EventViewModel { get; set; }

        public RelayCommand NewEventViewCommand { get; set; }
        public NewEventViewModel NewEventViewModel { get; set; }

        public RelayCommand NewStatusViewCommand { get; set; }
        public NewStatusViewModel NewStatusViewModel { get; set; }

        public RelayCommand StartViewCommand { get; set; }
        public StartViewModel StartViewModel { get; set; }


    }
}
