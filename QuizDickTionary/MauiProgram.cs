using Microsoft.Extensions.Logging;
using QuizDickTionary.Application.ViewModels;
using QuizDickTionary.Application.Models;

namespace QuizDickTionary
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IViewModelFactory, ViewModelFactory>();
            builder.Services.AddSingleton<MainWindowViewModel>();
            builder.Services.AddSingleton<WelcomeViewModel>();
            builder.Services.AddSingleton<EditWordsViewModel>();
            return builder.Build();
        }
    }
}
