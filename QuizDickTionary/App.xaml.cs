using QuizDickTionary.Application.Models;
using QuizDickTionary.Application.ViewModels;
using QuizDickTionary.Domain.Models;

namespace QuizDickTionary
{
    public partial class App 
    {
        private static WordDatabase _database;
        public static WordDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Words.db3"); // Fixed usage here
                    _database = new WordDatabase(dbPath);
                }
                return _database;
            }
        }
        public App(IViewModelFactory viewModelFactory)
        {
            InitializeComponent();
            var mainViewModel = viewModelFactory.CreateViewModel<MainWindowViewModel>();
            MainPage = mainViewModel.GetPage();
        }
    }
}
