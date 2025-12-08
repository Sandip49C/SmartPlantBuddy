using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Capstone_Project.Models
{
    public class SensorReading
    {
        [PrimaryKey, AutoIncrement]
        public int ReadingId { get; set; }
        public int SensorId { get; set; }
        public double MoistureLevel { get; set; }
        public double Temperature { get; set; }
        public string Timestamp { get; set; } = DateTime.UtcNow.ToString("o");
    }
}
