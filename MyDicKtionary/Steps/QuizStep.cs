using MyDicKtionary.Models;
using MyDicKtionary.View;
using MyDicKtionary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDicKtionary.Steps
{
    public class QuizStep
    {
        private QuizView _quizView;
        public QuizViewModel QuizViewModel;

        public QuizStep(List<Word> words)
        {
            QuizViewModel = new QuizViewModel(words);
            _quizView = new QuizView() { BindingContext = QuizViewModel };

            WorkFlowManager.SetCurrentPage(_quizView);
        }

        public ContentView GetView()
        {
            return _quizView;
        }
    }
}
