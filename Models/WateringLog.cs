using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Capstone_Project.Models
{
    public class WateringLog
    {
        [PrimaryKey, AutoIncrement]
        public int LogId { get; set; }
        public int UserId { get; set; }
        public int SensorId { get; set; }
        public string EventType { get; set; } = "manual"; // or "auto_pump"
        public string? Notes { get; set; }
        public string Timestamp { get; set; } = DateTime.UtcNow.ToString("o");
    }
}
