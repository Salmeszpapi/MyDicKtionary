using Microsoft.Maui.Storage; // Ensure this is included
using MyDicKtionary.ViewModel;
using MyDicKtionary.View;
using MyDicKtionary.Steps;
using MyDicKtionary.Models;
using System.IO; // Ensure this is included for Path and Directory

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
                    string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Words.db3"); // Fixed usage here
                    _database = new WordDatabase(dbPath);
                }
                return _database;
            }
        }

        public App(MainStep mainStep)
        {
            InitializeComponent();
            InitializeDatabase(); // No need to do this here if already done in Database property
            MainPage = mainStep.GetView();
        }

        private void InitializeDatabase()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Words.db3"); // Fixed usage here
            _database = new WordDatabase(dbPath);
        }
    }
}
