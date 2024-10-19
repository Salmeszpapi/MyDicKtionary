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

        public ContentView ContentView
        {
            get { return _contentView; }
            set
            {
                InternalSetPropertyValue(ref _contentView, value, nameof(ContentView));
            }
        }

        public MainWindowViewModel(IViewModelFactory viewModelFactory) : base(viewModelFactory) 
        {
            WelcomeViewModel welcomeViewModel= viewModelFactory.CreateViewModel<WelcomeViewModel>();
            ContentView = welcomeViewModel.GetView();
            _mainWindowLayout = new MainWindowLayout() { BindingContext = this };
        }
        public ContentPage GetPage()
        {
            return _mainWindowLayout;
        }

        public void SetContentView(ContentView contentView)
        {
            ContentView = contentView;
        }
    }
}
