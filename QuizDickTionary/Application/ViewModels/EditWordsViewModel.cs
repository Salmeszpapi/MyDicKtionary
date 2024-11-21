using QuizDickTionary.Application.Views;
using QuizDickTionary.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using QuizDickTionary.Domain.Dtos;
using QuizDickTionary.Domain.Models;
using System.Windows.Input;

namespace QuizDickTionary.Application.ViewModels
{
    public class EditWordsViewModel : BaseViewModel
    {
        public Command OnRemainingItemsThresholdReachedCommand;

        private List<WordDto> _words = new List<WordDto>();
        private const int PageSize = 50;
        private int _currentPage = 0;
        public double Transparency => 0.5;
        public ObservableCollection<Word> DictionaryWords { get; private set; } = new ObservableCollection<Word>();
        public ICommand EditWordCommand { get; private set; }
        private EditWordsView _editWordsView;
        public EditWordsViewModel(IViewModelFactory viewModelFactory) : base(viewModelFactory)
        {
            _editWordsView = new EditWordsView() { BindingContext = this };
            EditWordCommand = new Command<Word>(ToggleEditMode);
            InicializeAsync();
        }

        private async void InicializeAsync()
        {
            var words = await App.Database.GetWordsAsync();
            foreach (var word in words)
            {
                var wordViewModel = new Word(word);
                DictionaryWords.Add(wordViewModel);
            }
        }

        public void OnRemainingItemsThresholdReached(object sender, EventArgs e)
        {
            LoadMoreWords(); // Call the method to load more items
        }

        public ContentView GetView()
        {
            return _editWordsView;
        }

        public async Task LoadMoreWords()
        {

            var newWords = await App.Database.GetPagedWordsAsync(_currentPage * PageSize, PageSize);
            foreach (var word in newWords)
            {
                var wordViewModel = new Word(word); // Wrap DTO in ViewModel
                DictionaryWords.Add(wordViewModel);
            }
            _currentPage++;
        }

        private void ToggleEditMode(Word word)
        {
            if (word != null)
            {
                word.IsEditing = !word.IsEditing;  // Toggle the IsEditing property
            }
        }

    }
}
