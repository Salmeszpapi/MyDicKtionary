using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyDicKtionary.ViewModel
{
    public class QuizSubStateViewModel : INotifyPropertyChanged
    {
        private int _quizQuestions;

        public QuizSubStateViewModel()
        {
            StartQuiz = new Command(StartQuizButton);
        }

        public Command StartQuiz { get; set; }
        public int QuizQuestions
        {
            get { return _quizQuestions; }
            set
            {
                _quizQuestions = value;
                OnPropertyChanegd(nameof(QuizQuestions));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void StartQuizButton()
        {

        }

        public void OnPropertyChanegd(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
