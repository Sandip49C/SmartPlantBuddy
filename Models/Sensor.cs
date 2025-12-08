using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Capstone_Project.Models
{
    public class Sensor
    {
        [PrimaryKey, AutoIncrement]
        public int SensorId { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; } = "soil_moisture";
        public string Location { get; set; } = "Kitchen Windowsill";
    }
}
