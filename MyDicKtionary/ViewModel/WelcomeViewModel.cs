using MyDicKtionary.Models;
using MyDicKtionary.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDicKtionary.ViewModel
{
    public class WelcomeViewModel : INotifyPropertyChanged
    {
        public WelcomeViewModel(ExcelAgregator excelAgregator)
        {
            StartQuizCommand = new Command(async () => await StartQuizAsync());
            _excelAgregator = excelAgregator;
        }
        public Command StartQuizCommand { get; set; }
        public List<Word> DictionaryWords { get; set; }
        private ExcelAgregator _excelAgregator;

        public event PropertyChangedEventHandler? PropertyChanged;

        private async Task StartQuizAsync()
        {
            _excelAgregator.ProcessExcel(); // If this method is async, you should await it too
            DictionaryWords = await App.Database.GetWordsAsync(); // Await the async database operation
            OnPropertyChange(nameof(DictionaryWords)); // Notify UI about the change
        }

        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
