using QuizDickTionary.Application.Views;
using QuizDickTionary.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using QuizDickTionary.Domain.Dtos;

namespace QuizDickTionary.Application.ViewModels
{
    public class EditWordsViewModel : BaseViewModel
    {
        private List<WordDto> _words = new List<WordDto>();
        public List<WordDto> DictionaryWords {
            get { return _words; }
            private set
            {
                InternalSetPropertyValue(ref _words, value, nameof(DictionaryWords));
            }
        }

        private EditWordsView _editWordsView;
        public EditWordsViewModel(IViewModelFactory viewModelFactory) : base(viewModelFactory)
        {
            _editWordsView = new EditWordsView() { BindingContext = this};

            InicializeAsync();
        }

        private async void InicializeAsync()
        {
            DictionaryWords = await App.Database.GetWordsAsync();
        }

        public ContentView GetView()
        {
            return _editWordsView;
        }
    }
}
