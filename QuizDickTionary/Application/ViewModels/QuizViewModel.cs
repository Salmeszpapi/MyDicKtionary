using QuizDickTionary.Application.Models;
using QuizDickTionary.Application.ViewModels.Components;
using QuizDickTionary.Domain.Dtos;
using System.Collections.ObjectModel;

namespace QuizDickTionary.Application.ViewModels
{
    internal class QuizViewModel : BaseViewModel
    {
        private IViewModelFactory _viewModelFactory;
        public int CountOfQuestions { get; set; } = 5;
        public string QuestionIndex { get; set; } = "hellooo";
        public ObservableCollection<WordViewModel> ObservableWordsViewModel { get; }
        private WordViewModel _question;

        public WordViewModel Question
        {
            get { return _question; }
            set { InternalSetPropertyValue(ref _question, value); }
        }

        public QuizViewModel(IViewModelFactory viewModelFactory) : base (viewModelFactory)
        {
            ObservableWordsViewModel = new ObservableCollection<WordViewModel>();
            _viewModelFactory = viewModelFactory;
            LoadQuizViewModels();
        }

        private async void LoadQuizViewModels()
        {
            List<WordDto> words = await App.Database.GetWordsForQuiz(CountOfQuestions);

            foreach (var word in words)
            {
                WordViewModel wordViewModel = new WordViewModel(_viewModelFactory);
                wordViewModel.InitializeContent(word);
                ObservableWordsViewModel.Add(wordViewModel);
                Question = wordViewModel;
            }
        }
    }
}
