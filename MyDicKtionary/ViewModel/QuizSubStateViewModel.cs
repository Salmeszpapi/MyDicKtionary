using MyDicKtionary.Models;
using MyDicKtionary.View;
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
        public Command StartQuiz { get; set; }
        public QuizSubstate QuizSubstateView;
        public QuizSubStateViewModel()
        {
            StartQuiz = new Command(StartQuizButton);
        }

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
            QuizSubstateView.CloseAsync(QuizResultEnum.Start);
        }

        public void OnPropertyChanegd(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
