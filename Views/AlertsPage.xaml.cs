using CommunityToolkit.Mvvm.Input;
using SmartPlantBuddy.Services;

namespace SmartPlantBuddy.Views
{
    public partial class AlertsPage : ContentPage
    {
        public AlertsPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        [RelayCommand]
        async Task SendTestAlert()
        {
            Vibration.Vibrate(500);
            var notif = MauiProgram.Services.GetRequiredService<NotificationService>();
            await notif.ShowLowMoistureAlert(25);
        }
    }
}