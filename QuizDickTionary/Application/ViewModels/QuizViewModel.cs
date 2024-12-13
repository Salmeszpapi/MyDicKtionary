using QuizDickTionary.Domain.Dtos;

namespace QuizDickTionary.Application.ViewModels
{
    internal class QuizViewModel
    {
        public int CountOfQuestions { get; set; } = 5;// for default i set 5 
        public string QuestionIndex { get; set; } = "hellooo";
        public List<WordDto> Words { get; set; }
        public QuizViewModel()
        {
            LoadQuizWords();
        }

        private async void LoadQuizWords()
        {
            Words = await App.Database.GetWordsForQuiz(CountOfQuestions);
        }
    }
}
