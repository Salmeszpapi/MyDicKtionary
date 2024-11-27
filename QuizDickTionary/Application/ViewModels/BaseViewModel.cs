using QuizDickTionary.Application.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QuizDickTionary.Application.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private readonly IViewModelFactory viewModelFactory;

        public BaseViewModel(IViewModelFactory viewModelFactory)
        {
            this.viewModelFactory = viewModelFactory;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public MainWindowViewModel MainWindowViewModel { get; set; }
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void OnModelLoaded()
        {
            MainWindowViewModel = viewModelFactory.CreateViewModel<MainWindowViewModel>();
        }

        protected void InternalSetPropertyValue<T>(ref T field, T value, [CallerMemberName] string propertyName="")
        {
            if (!Equals(field, value))
            {
                field = value;
                OnPropertyChanged(propertyName);
            }
        }
    }
}