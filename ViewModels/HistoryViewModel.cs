using CommunityToolkit.Mvvm.ComponentModel;

namespace SmartPlantBuddy.ViewModels
{
    public partial class HistoryViewModel : ObservableObject
    {
        [ObservableProperty]
        string message = "Watering history will appear here";
    }
}