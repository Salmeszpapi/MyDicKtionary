using MyDicKtionary.Models;
using MyDicKtionary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDicKtionary.ViewModel
{
    public class WelcomeViewModel
    {
        public WelcomeViewModel(ExcelAgregator excelAgregator)
        {
            StartQuizCommand = new Command(StartQuiz);
            _excelAgregator = excelAgregator;
        }
        public Command StartQuizCommand { get; set; }
        public List<Word> DictionaryWords { get; set; }
        private ExcelAgregator _excelAgregator;

        private void StartQuiz()
        {
            _excelAgregator.ProcessExcel();
            var test  = App.Database.GetWordsAsync();
        }
    }
}
