using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using MyDicKtionary.Models;
using MyDicKtionary.Steps;
using MyDicKtionary.Util;
using MyDicKtionary.ViewModel;

namespace MyDicKtionary
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
            builder.Services.AddSingleton<ExcelAgregator>();
            builder.Services.AddSingleton<WelcomeStep>();
            builder.Services.AddSingleton<WelcomeViewModel>();
            return builder.Build();
        }
    }
}
