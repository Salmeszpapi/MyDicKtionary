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
using QuizDickTionary.Application.ViewModels.Components;

namespace QuizDickTionary.Application.ViewModels
{
    public class EditWordsViewModel : BaseViewModel
    {
        private readonly int _pageSize = 50;
        private int _currentPage = 0;
        private IViewModelFactory _viewModelFactory;
        private EditWordsView _contentView;


        public ObservableCollection<EditWordViewModel> DictionaryWords { get; } = new ObservableCollection<EditWordViewModel>();
        public ICommand LoadMoreCommand { get; }


        public EditWordsViewModel(IViewModelFactory viewModelFactory) : base(viewModelFactory) 
        {
            _viewModelFactory = viewModelFactory;
            LoadMoreCommand = new Command(async () => await LoadMoreWordsAsync());
            _contentView = new EditWordsView() { BindingContext = this };
            InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            var words = await App.Database.GetWordsAsync();
            AddWordsToCollection(words);
        }

        private async Task LoadMoreWordsAsync()
        {
            var newWords = await App.Database.GetPagedWordsAsync(_currentPage * _pageSize, _pageSize);
            AddWordsToCollection(newWords);
            _currentPage++;
        }

        private void AddWordsToCollection(IEnumerable<WordDto> wordDtos)
        {
            foreach (var dto in wordDtos)
            {
                var wordViewModel = _viewModelFactory.CreateViewModel<EditWordViewModel>();
                wordViewModel.InitializeContent(dto);
                DictionaryWords.Add(wordViewModel);
            }
        }

        public ContentView GetView()
        {
            return _contentView;
        }
    }
}
