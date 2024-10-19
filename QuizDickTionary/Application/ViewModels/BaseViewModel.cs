using QuizDickTionary.Application.Models;
using System.ComponentModel;

namespace QuizDickTionary.Application.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private readonly IViewModelFactory viewModelFactory;

        public BaseViewModel(IViewModelFactory viewModelFactory)
        {
            //MainWindowViewModel = viewModelFactory.CreateViewModel<MainWindowViewModel>();
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public MainWindowViewModel MainWindowViewModel { get; set; }
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void InternalSetPropertyValue<T>(ref T field, T value, string propertyName)
        {
            if (!Equals(field, value))
            {
                field = value;
                OnPropertyChanged(propertyName);
            }
        }
    }
}