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
            _mainWindowLayout = new MainWindowLayout() { BindingContext = this };
            
            ContentView = viewModelFactory.CreateViewModel<WelcomeViewModel>().GetView();
        }
        public ContentPage GetPage()
        {
            return _mainWindowLayout;
        }
    }
}
