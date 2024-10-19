using QuizDickTionary.Application.Models;
using QuizDickTionary.Application.Views;
using QuizDickTionary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDickTionary.Application.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        private WelcomeView _contentView;
        public Command EditCommand { get; set; }
        public Command StartQuizCommand { get; set; }
        public Command HystoryCommand { get; set; }
        public Command SettingsCommand { get; set; }
        private Task databaseFetchTask;
        private readonly IViewModelFactory _viewModelFactory;
        public WelcomeViewModel(IViewModelFactory viewModelFactory) : base(viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
            SettingsCommand = new Command(OpenSettings);
            EditCommand = new Command(EditWords);
            StartQuizCommand = new Command(StartQuiz);
            HystoryCommand = new Command(OpenHystory);

            inicializeDatabase();
            _contentView = new WelcomeView() {  BindingContext = this};
        }

        private async void inicializeDatabase()
        {
            if (!await App.Database.IsEmptyTable())
            {
                databaseFetchTask = ApiDataProvider.ReadExcel();
            }
        }

        public async Task ReadExcel()
        {
            databaseFetchTask.Wait();
        }
        public ContentView GetView()
        {
            return _contentView;
        }
        private void OpenSettings()
        {

            
        }

        private void StartQuiz()
        {
            databaseFetchTask.Wait();
        }

        private void OpenHystory()
        {
            databaseFetchTask.Wait();
        }

        private async void EditWords()
        {
            OnModelLoaded();
            var mainWidnow =  _viewModelFactory.CreateViewModel<MainWindowViewModel>();
            await databaseFetchTask;
            var _dictionaryWords = await App.Database.GetWordsAsync();
            if (!_dictionaryWords.Any())
            {
            }
            EditWordsViewModel editWordsViewModel = _viewModelFactory.CreateViewModel<EditWordsViewModel>();
            MainWindowViewModel.ContentView = editWordsViewModel.GetView();
        }
    }
}
