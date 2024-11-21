using QuizDickTionary.Application.Models;
using QuizDickTionary.Application.ViewModels;
using QuizDickTionary.Domain.Models;
using QuizDickTionary.Services;

namespace QuizDickTionary
{
    public partial class App
    {
        private static WordDatabase _database;
        public static WordDatabase Database => _database;

        public App(WordDatabase database, IViewModelFactory viewModelFactory)
        {
            InitializeComponent();

            _database = database;
            InitializeAsync().ConfigureAwait(true); // Call async initialization here
            var mainViewModel = viewModelFactory.CreateViewModel<MainWindowViewModel>();
            MainPage = mainViewModel.GetPage();
        }

        private async Task InitializeAsync()
        {
            var records = await App.Database.GetWordDtoRecordCountAsync();
            if (records == 0)
            {
                await ApiDataProvider.ReadExcel();
            }
        }
    }
}
