using QuizDickTionary.Application.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDickTionary.Application.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        private WelcomeView _contentView;
        public WelcomeViewModel()
        {
            _contentView = new WelcomeView() {  BindingContext = this};
        }

        public ContentView GetView()
        {
            return _contentView;
        }
    }
}
