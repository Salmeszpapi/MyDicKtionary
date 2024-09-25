using MyDicKtionary.Steps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDicKtionary.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ContentView _contentView;
        public ContentView CurrentView
        {
            get { return _contentView; }
            set 
            { 
                _contentView = value;
                OnPropertyChange(nameof(CurrentView));
            }
        }

        public MainViewModel(MainStep mainStep)
        {
            WelcomeStep welcomeStep = new WelcomeStep(mainStep);
            CurrentView = welcomeStep.GetView();
            OnPropertyChange(nameof(CurrentView));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void SetView(ContentView view)
        {
            CurrentView = view;
        }
    }
}
