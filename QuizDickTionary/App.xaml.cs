using QuizDickTionary.Application.Models;
using QuizDickTionary.Application.ViewModels;
using QuizDickTionary.Domain.Models;
using QuizDickTionary.Services;

namespace QuizDickTionary
{
    public partial class App
    {
        private static WordDatabase _database;
        public static WordDatabase Database
        {
            get
            {
                return _database;
            }
        }
        public App(IViewModelFactory viewModelFactory)
        {
            InitializeComponent();
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Words.db3"); // Fixed usage here
            _database = new WordDatabase(dbPath);
            InitializeAsync();
            var mainViewModel = viewModelFactory.CreateViewModel<MainWindowViewModel>();
            MainPage = mainViewModel.GetPage();
        }

        private async Task InitializeAsync()
        {
            if (await _database.IsEmptyTable())
            {
                await ApiDataProvider.ReadExcel();
            }
        }
    }
}
