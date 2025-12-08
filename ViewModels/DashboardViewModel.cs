using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartPlantBuddy.ViewModels
{
    public partial class DashboardViewModel : ObservableObject
    {
        [ObservableProperty] double currentMoisture = 45;
        [ObservableProperty] double currentTemp = 72;

        public DashboardViewModel()
        {
            // Simulate sensor reading
            Device.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                CurrentMoisture = Random.Shared.Next(20, 80);
                CurrentTemp = Random.Shared.Next(65, 85);
                return true;
            });
        }
    }
}