using Plugin.LocalNotification;

namespace SmartPlantBuddy.Services
{
    public class NotificationService
    {
        public async Task ShowLowMoistureAlert(double moisture)
        {
            Vibration.Vibrate(500);

            var notification = new NotificationRequest
            {
                NotificationId = 100,
                Title = "Plant Needs Water!",
                Description = $"Soil moisture is critically low: {moisture:F1}%",
                Schedule = { NotifyTime = DateTime.Now.AddSeconds(2) }
            };

            await LocalNotificationCenter.Current.Show(notification);
        }
    }
}