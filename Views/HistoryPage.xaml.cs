using SmartPlantBuddy.ViewModels;

namespace SmartPlantBuddy.Views
{
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage(HistoryViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}