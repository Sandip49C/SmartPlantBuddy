using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPlantBuddy.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = DateTime.UtcNow.ToString("o");
    }
}
