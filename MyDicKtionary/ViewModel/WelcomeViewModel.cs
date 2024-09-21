using MyDicKtionary.Models;
using MyDicKtionary.Services;
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
            ExcelDataService excelDataService = new ExcelDataService();
            await _excelAgregator.ReadExcel();
            DictionaryWords = await App.Database.GetWordsAsync(); 
            OnPropertyChange(nameof(DictionaryWords));
        }

        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
