using chart.DatabaseService;
using chart.Repositories;
using chart.ViewModel;
using chart.ViewModel.Base;
using chart.ViewModel.Postss;
using Microsoft.Extensions.Logging;

namespace chart
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

            // register settings
            builder.Services.AddSingleton<DatabaseSettings>();

            // register pages
            builder.Services.AddSingleton<MainPage>();  // Добавляем MainPage

            // register repository
            builder.Services.AddSingleton<PostsRepository>();

            // register ViewModels
            builder.Services.AddSingleton<PostsViewModel>();  // Добавляем PostsViewModel
            

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
