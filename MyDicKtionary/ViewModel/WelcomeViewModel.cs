using MyDicKtionary.Models;
using MyDicKtionary.Services;
using MyDicKtionary.Util;
using MyDicKtionary.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using MyDicKtionary.Steps;

namespace MyDicKtionary.ViewModel
{
    public class WelcomeViewModel : INotifyPropertyChanged
    {
        private MainStep _mainStep;
        public Command StartQuizCommand { get; set; }
        public Command StartEdit { get; set; }
        public Command StartHistory { get; set; }
        public Command StartQuize { get; set; }
        public WelcomeViewModel(MainStep mainStep)
        {
            StartQuizCommand = new Command(async () => await StartQuizAsync());
            StartEdit = new Command(async () => await StartEditAsync());
            StartQuizCommand = new Command(async () => await StartHistoryAsync());
            StartQuizCommand = new Command(async () => await StartSettingsAsync());
            _mainStep = mainStep;
        }

        private async Task StartEditAsync()
        {
            _dictionaryWords = await App.Database.GetWordsAsync();
            QuizStep quizStep = new QuizStep(_dictionaryWords);
            WorkFlowManager.SetCurrentPage(quizStep.GetView());
            _mainStep.GetViewModel().CurrentView = quizStep.GetView();
        }

        private async Task StartHistoryAsync()
        {
            throw new NotImplementedException();
        }

        private async Task StartSettingsAsync()
        {
            QuizSubStateStep quizSubStateStep = new QuizSubStateStep();
            var result = await _mainStep.GetView().ShowPopupAsync(quizSubStateStep.GetPopup());

            if (result is null)
            {
                return;
            }
            switch (result)
            {
                case QuizResultEnum.Start:
                   _dictionaryWords = await App.Database.GetWordsAsync();
                    if (!_dictionaryWords.Any())
                    {
                        _dictionaryWords =  await ReadExcelWordsToDatabase();
                    }

                    QuizStep quizStep = new QuizStep(_dictionaryWords);
                    WorkFlowManager.SetCurrentPage(quizStep.GetView());
                    _mainStep.GetViewModel().CurrentView = quizStep.GetView();

                    break;
                case QuizResultEnum.Closed:
                    return;
            }

        }

        public async Task<List<Word>> ReadExcelWordsToDatabase()
        {
            ExcelDataService excelDataService = new ExcelDataService();
            await ExcelAgregator.ReadExcel();
            _dictionaryWords = await App.Database.GetWordsAsync();
            
            return _dictionaryWords;
        }

        private List<Word> _dictionaryWords { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private async Task<List<Word>> StartQuizAsync()
        {
            ExcelDataService excelDataService = new ExcelDataService();
            _dictionaryWords = await App.Database.GetWordsAsync();
            OnPropertyChange(nameof(_dictionaryWords));
            return _dictionaryWords;
        }

        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
