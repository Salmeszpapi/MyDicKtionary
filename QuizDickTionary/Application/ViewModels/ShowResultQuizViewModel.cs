using QuizDickTionary.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDickTionary.Application.ViewModels
{
    public class ShowResultQuizViewModel
    {
        public ShowResultQuizViewModel(List<WordWithAnswer> wordWithAnswers)
        {
            WordWithAnswers = wordWithAnswers;
        }

        public List<WordWithAnswer> WordWithAnswers { get; }
    }
}
