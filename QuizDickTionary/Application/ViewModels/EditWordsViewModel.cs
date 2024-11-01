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
        public Command OnRemainingItemsThresholdReachedCommand;
        
        private List<WordDto> _words = new List<WordDto>();
        private const int PageSize = 50;
        private int _currentPage = 0;

        public ObservableCollection<WordDto> DictionaryWords { get; private set; } = new ObservableCollection<WordDto>();

        private EditWordsView _editWordsView;
        public EditWordsViewModel(IViewModelFactory viewModelFactory) : base(viewModelFactory)
        {
            _editWordsView = new EditWordsView() { BindingContext = this};
            InicializeAsync();
        }

        private async void InicializeAsync()
        {
            var words = await App.Database.GetWordsAsync();
            foreach (var word in words)
            {
                DictionaryWords.Add(word); // Populate the ObservableCollection
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
                DictionaryWords.Add(word); // Add new words to the ObservableCollection
            }
            _currentPage++;
        }
    }
}
