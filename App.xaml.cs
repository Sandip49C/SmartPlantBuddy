using SmartPlantBuddy.Services;
using SmartPlantBuddy.Views;

namespace SmartPlantBuddy
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window();
            _ = SetInitialPageAsync(window);
            return window;
        }

        private async Task SetInitialPageAsync(Window window)
        {
            var auth = MauiProgram.Services.GetService<IAuthService>();
            Page initialPage;

            if (auth != null && await auth.IsLoggedInAsync())
            {
                initialPage = new AppShell();
            }
            else
            {
                var loginViewModel = MauiProgram.Services.GetService<ViewModels.LoginViewModel>();
                initialPage = new LoginPage(loginViewModel!);
            }

            MainThread.BeginInvokeOnMainThread(() =>
            {
                window.Page = initialPage;
            });
        }
    }
}