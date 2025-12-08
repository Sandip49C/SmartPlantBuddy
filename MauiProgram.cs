using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
using SmartPlantBuddy.Data;
using SmartPlantBuddy.Services;
using SmartPlantBuddy.ViewModels;
using SmartPlantBuddy.Views;

namespace SmartPlantBuddy
{
    public static class MauiProgram
    {
        public static IServiceProvider Services { get; private set; } = null!;

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Configure MAUI app with all extensions in fluent chain
            builder
                .UseMauiApp<App>()
                .UseLocalNotification()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Register AppDbContext factory first - created when first requested
            builder.Services.AddSingleton<AppDbContext>(sp =>
            {
                string appDataDir;
                try
                {
                    appDataDir = FileSystem.AppDataDirectory;
                }
                catch
                {
                    appDataDir = null;
                }

                if (string.IsNullOrWhiteSpace(appDataDir))
                {
                    appDataDir = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "SmartPlantBuddy");
                }

                var dbPath = Path.Combine(appDataDir, "plantbuddy.db3");
                var dbDir = Path.GetDirectoryName(dbPath);

                if (!string.IsNullOrWhiteSpace(dbDir) && !Directory.Exists(dbDir))
                {
                    Directory.CreateDirectory(dbDir);
                }

                return new AppDbContext(dbPath);
            });

            // Services - Register interfaces, implementations will be created lazily
            builder.Services.AddSingleton<IAuthService, AuthService>();
            builder.Services.AddSingleton<NotificationService>();
            builder.Services.AddSingleton<IWeatherService, WeatherService>();

            // ViewModels
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<DashboardViewModel>();
            builder.Services.AddTransient<HistoryViewModel>();

            // Pages
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<DashboardPage>();
            builder.Services.AddTransient<HistoryPage>();
            builder.Services.AddTransient<AlertsPage>();

            var app = builder.Build();
            Services = app.Services;
            return app;
        }
    }
}