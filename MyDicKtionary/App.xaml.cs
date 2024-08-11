using MyDicKtionary.ViewModel;
using MyDicKtionary.View;
using MyDicKtionary.Steps;
using MyDicKtionary.Models;
namespace MyDicKtionary
{
    public partial class App : Application
    {
        private static WordDatabase _database;
        public static WordDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Words.db3");
                    _database = new WordDatabase(dbPath);
                }
                return _database;
            }
        }
        public App(WelcomeStep welcomeStep)
        {
            InitializeComponent();
            MainPage = welcomeStep.GetView();
        }
    }
}
