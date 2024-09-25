using CommunityToolkit.Maui.Views;
using MyDicKtionary.View;
using MyDicKtionary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDicKtionary.Steps
{
    class QuizSubStateStep
    {
        private QuizSubStateViewModel quizSubStateViewModel { get; set; }
        private QuizSubstate quizSubstateView { get; set; }

        public QuizSubStateStep()
        {
            quizSubStateViewModel = new QuizSubStateViewModel();
            quizSubstateView = new QuizSubstate() { BindingContext = quizSubStateViewModel };
        }

        public Popup GetPopup()
        {
            return quizSubstateView;
        }
    }
}
