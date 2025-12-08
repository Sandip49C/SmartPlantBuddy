using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartPlantBuddy.Services;

namespace SmartPlantBuddy.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty] string email = "test@plant.com";
        [ObservableProperty] string password = "123456";

        private readonly IAuthService _authService;

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        async Task Login()
        {
            if (await _authService.LoginAsync(Email, Password))
            {
                if (Application.Current?.Windows.Count > 0)
                {
                    Application.Current.Windows[0].Page = new AppShell();
                }
            }
            else
            {
                if (Application.Current?.Windows.Count > 0)
                {
                    var page = Application.Current.Windows[0].Page;
                    if (page != null)
                    {
                        await page.DisplayAlertAsync("Error", "Invalid login", "OK");
                    }
                }
            }
        }
    }
}