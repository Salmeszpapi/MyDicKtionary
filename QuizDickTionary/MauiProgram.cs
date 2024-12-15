using Microsoft.Extensions.Logging;
using QuizDickTionary.Application.ViewModels;
using QuizDickTionary.Application.Models;
using QuizDickTionary.Domain.Models;
using CommunityToolkit.Maui;
using QuizDickTionary.Application.ViewModels.Components;

namespace QuizDickTionary
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton(s => new WordDatabase(Path.Combine(FileSystem.AppDataDirectory, "Words.db3")));
            builder.Services.AddSingleton<IViewModelFactory, ViewModelFactory>();
            builder.Services.AddSingleton<MainWindowViewModel>();
            builder.Services.AddSingleton<WelcomeViewModel>();
            builder.Services.AddSingleton<EditWordsViewModel>();
            builder.Services.AddTransient<EditWordViewModel>();

            return builder.Build();
        }
    }
}
