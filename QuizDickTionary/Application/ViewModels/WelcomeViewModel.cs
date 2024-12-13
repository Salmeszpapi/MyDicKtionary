using QuizDickTionary.Application.Models;
using QuizDickTionary.Application.ViewModels.Incident;
using QuizDickTionary.Application.Views;
using QuizDickTionary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace QuizDickTionary.Application.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        private WelcomeView _contentView;
        public Command EditCommand { get; set; }
        public Command StartQuizCommand { get; set; }
        public Command HystoryCommand { get; set; }
        public Command SettingsCommand { get; set; }
        private readonly IViewModelFactory _viewModelFactory;
        private EditWordsViewModel _editWordsViewModel;
        public WelcomeViewModel(IViewModelFactory viewModelFactory) : base(viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
            SettingsCommand = new Command(OpenSettings);
            EditCommand = new Command(EditWords);
            StartQuizCommand = new Command(StartQuiz);
            HystoryCommand = new Command(OpenHystory);
            _editWordsViewModel = _viewModelFactory.CreateViewModel<EditWordsViewModel>();
            _contentView = new WelcomeView() {  BindingContext = this};
        }

        public async Task ReadExcel()
        {
        }
        public ContentView GetView()
        {
            return _contentView;
        }
        private void OpenSettings()
        {

            
        }

        private async void StartQuiz()
        {
            OnModelLoaded();
            QuizViewModel viewModel = new QuizViewModel();
            QuizView quizView = new QuizView() { BindingContext = viewModel};

            MainWindowViewModel.ContentView = quizView;
        }

        private void OpenHystory()
        {
        }

        private async void EditWords()
        {
            OnModelLoaded();
            var _dictionaryWords = await App.Database.GetWordsAsync();
            if (!_dictionaryWords.Any()) // in case there are no words, try to reload the dictionary from the server 
            {
                var result = await App.Current.MainPage.DisplayAlert("Test", "Do you want load words from server?", "Yes", "No");
                if (result)
                {
                    await ApiDataProvider.ReadExcel();
                }
            }

            MainWindowViewModel.ContentView = _editWordsViewModel.GetView();
        }
    }
}
