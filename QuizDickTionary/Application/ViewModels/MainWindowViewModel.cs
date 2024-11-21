using QuizDickTionary.Application.Models;
using QuizDickTionary.Application.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDickTionary.Application.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private MainWindowLayout _mainWindowLayout;
        private ContentView _contentView;
        private List<ContentView> previousPages = new List<ContentView>();
        
        public MainWindowViewModel(IViewModelFactory viewModelFactory) : base(viewModelFactory) 
        {
            BackToPreviousViewCommand = new Command(ReturnToPreviousView);
            ContentView = viewModelFactory.CreateViewModel<WelcomeViewModel>().GetView();
            _mainWindowLayout = new MainWindowLayout() { BindingContext = this };
        }

        private void ReturnToPreviousView(object obj)
        {
            if (previousPages.Any())
            {
                ContentView = previousPages.Last();
                previousPages.Remove(previousPages.Last());
            }            
        }

        public Command BackToPreviousViewCommand { get; set; }

        public ContentView ContentView
        {
            get { return _contentView; }
            set
            {
                if (_contentView != null)
                {
                    previousPages.Add(_contentView);
                    IsBackButtonEnabled = !_isBackButtonEnabled;
                }

                InternalSetPropertyValue(ref _contentView, value, nameof(ContentView));
            }
        }

        private bool _isBackButtonEnabled;

        public bool IsBackButtonEnabled
        {
            get => _isBackButtonEnabled;
            set
            {
                if (_isBackButtonEnabled != value)
                {
                    _isBackButtonEnabled = value;
                    OnPropertyChanged(nameof(IsBackButtonEnabled));
                }
            }
        }

        public void ToggleBackButton()
        {
            IsBackButtonEnabled = !IsBackButtonEnabled;
        }

        public ContentPage GetPage()
        {
            return _mainWindowLayout;
        }
    }
}
