using MyDicKtionary.Models;
using MyDicKtionary.View;
using MyDicKtionary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDicKtionary.Steps
{
    public class MainStep
    {
        private readonly MainView _mainView;
        private readonly MainViewModel _mainViewModel;

        public MainStep()
        {
            _mainViewModel = new MainViewModel(this);
            _mainView = new MainView() { BindingContext = _mainViewModel };
        }

        public ContentPage GetView()
        {
            return _mainView;
        }
        public MainViewModel GetViewModel()
        {
            return _mainViewModel;
        }
    }
}
