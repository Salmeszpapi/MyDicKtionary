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

        public WelcomeStep(MainStep mainStep)
        {
            viewModel = new WelcomeViewModel(mainStep);
            view = new WelcomeView() { BindingContext = viewModel};
            WorkFlowManager.SetCurrentPage(view);
        }
        public ContentView GetView()
        {   
            return view;
        }
    }
}
