// Models/Alert.cs
using SQLite;

namespace SmartPlantBuddy.Models
{
    public class Alert
    {
        [PrimaryKey, AutoIncrement]
        public int AlertId { get; set; }
        public int UserId { get; set; }
        public int ReadingId { get; set; }
        public string Type { get; set; } = "low_moisture";
        public string Timestamp { get; set; } = DateTime.UtcNow.ToString("o");
    }
}