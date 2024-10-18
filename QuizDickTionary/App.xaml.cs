using QuizDickTionary.Application.ViewModels;

namespace QuizDickTionary
{
    public partial class App 
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainWindowViewModel().GetPage();
        }
    }
}
