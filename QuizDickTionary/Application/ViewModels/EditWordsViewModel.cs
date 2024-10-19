using QuizDickTionary.Application.Views;
using QuizDickTionary.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDickTionary.Application.ViewModels
{
    public class EditWordsViewModel : BaseViewModel
    {
        private EditWordsView _editWordsView;
        public EditWordsViewModel(IViewModelFactory viewModelFactory) : base(viewModelFactory)
        {
            _editWordsView = new EditWordsView() { BindingContext = this};
        }

        public ContentView GetView()
        {
            return _editWordsView;
        }
    }
}
