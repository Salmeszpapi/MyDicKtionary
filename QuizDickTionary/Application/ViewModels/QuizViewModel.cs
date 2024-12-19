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
        private int _crurrentQuiazQuestion;
        private List<WordViewModel> _submitedAnswers = new List<WordViewModel>();
        public int CurrentQuizQuestion
        {
            get { return _crurrentQuiazQuestion; }
            set { InternalSetPropertyValue(ref _crurrentQuiazQuestion, value); }
        }
        public Command SubmitCommand { get; set; }

        private Timer _timer;

        public string QuestionIndex { get; set; } = "hellooo";
        public ObservableCollection<WordViewModel> ObservableWordsViewModel { get; }
        private WordViewModel _question;

        public WordViewModel Question
        {
            get { return _question; }
            set { InternalSetPropertyValue(ref _question, value); }
        }

        private string _submitButtonText = "Submit";

        public string SubmitButtonText
        {
            get { return _submitButtonText; }
            set { InternalSetPropertyValue(ref _submitButtonText, value); }
        }

        private TimeOnly _currentTime;

        public TimeOnly CurrentTime
        {
            get { return _currentTime; }
            set { _currentTime = value; }
        }

        public QuizViewModel(IViewModelFactory viewModelFactory) : base(viewModelFactory)
        {
            ObservableWordsViewModel = new ObservableCollection<WordViewModel>();
            _viewModelFactory = viewModelFactory;
            LoadQuizViewModels();
            SubmitCommand = new Command(SubmitAnswer);
        }

        private async void LoadQuizViewModels()
        {
            List<WordDto> words = await App.Database.GetWordsForQuiz(CountOfQuestions);

            foreach (var word in words)
            {
                WordViewModel wordViewModel = new WordViewModel(_viewModelFactory);
                wordViewModel.InitializeContent(word);
                ObservableWordsViewModel.Add(wordViewModel);
            }
            Question = ObservableWordsViewModel[CurrentQuizQuestion];
        }

        private void SubmitAnswer()
        {
            _submitedAnswers.Add(ObservableWordsViewModel[_crurrentQuiazQuestion]);
            SafeIncementation();
            if (IsFinishPressed())
            {
                // new view with summary 
                ElaborateResults();
                return;
            }

            Question = ObservableWordsViewModel[_crurrentQuiazQuestion];
        }

        private void ElaborateResults()
        {
            foreach (var question in _submitedAnswers)
            {

            }
        }

        private void SafeIncementation()
        {
            if (CountOfQuestions - 1 > _crurrentQuiazQuestion)
            {
                CurrentQuizQuestion++;
            }
        }

        private bool IsFinishPressed()
        {
            if (CountOfQuestions - 1 == _crurrentQuiazQuestion)
            {
                SubmitButtonText = "Finish";
                return true;
            }
            return false;
        }
    }
}
