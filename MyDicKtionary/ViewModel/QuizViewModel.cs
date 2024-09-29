using MyDicKtionary.Models;
using MyDicKtionary.Services;
using MyDicKtionary.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDicKtionary.ViewModel
{
    public class QuizViewModel : BaseViewModel
    {
        public ObservableCollection<Word> DictionaryWords { get; set; }
        private List<Word> _modifiedWords = new List<Word>();
        public Command UpdateWords { get; set; }
        public Command HandleTextChangedCommand { get; set; }
        public QuizViewModel(List<Word> words)
        {
            DictionaryWords = new ObservableCollection<Word>(words);
            UpdateWords = new Command(UpdateWordsToDb);
            foreach (var item in DictionaryWords)
            {
                item.PropertyChanged += WordModified;
            }
        }

        public void WordModified(object sender, PropertyChangedEventArgs e)
        {
            if(sender is Word)
            {
                var word = (Word)sender;
                _modifiedWords.Add(word);
            }
        }

        private void UpdateWordsToDb()
        {
            App.Database.UpdateDictionary(_modifiedWords.Distinct<Word>().ToList());
        }
    }
}
