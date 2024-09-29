using Android.Media.TV.Interactive;
using MyDicKtionary.Models;
using MyDicKtionary.Services;
using MyDicKtionary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDicKtionary.ViewModel
{
    public class QuizViewModel : BaseViewModel
    {
        public List<Word> DictionaryWords { get; set; }
        public Command UpdateWords { get; set; }
        public ICommand HandleTextChangedCommand { get; set; }
        public QuizViewModel(List<Word> words)
        {
            DictionaryWords = words;
            UpdateWords = new Command(UpdateWordsToDb);
            HandleTextChangedCommand = new Command<Word>(TextChanged);
        }

        private void TextChanged(object obj)
        {

        }

        private void UpdateWordsToDb()
        {

        }
    }
}
