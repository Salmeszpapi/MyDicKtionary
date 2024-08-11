using MyDicKtionary.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDicKtionary.ViewModel;
using MyDicKtionary.Models;

namespace MyDicKtionary.Steps
{
    public class WelcomeStep
    {
        private WelcomeView view;
        private WelcomeViewModel viewModel;

        public WelcomeStep(IViewModelFactory viewModelFactory)
        {
            viewModel = viewModelFactory.Create<WelcomeViewModel>();
            view = new WelcomeView() { BindingContext = viewModel};
        }
        public ContentPage GetView()
        {   
            return view;
        }
    }
}
